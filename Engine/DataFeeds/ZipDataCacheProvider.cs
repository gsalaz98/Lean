/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using QuantConnect.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zip;
using Ionic.Zlib;
using QuantConnect.Interfaces;
using QuantConnect.Util;

namespace QuantConnect.Lean.Engine.DataFeeds
{
    /// <summary>
    /// File provider implements optimized zip archives caching facility. Cache is thread safe.
    /// </summary>
    public class ZipDataCacheProvider : IDataCacheProvider
    {
        private const int CacheSeconds = 10;

        // ZipArchive cache used by the class
        private static Dictionary<string, CachedZipFile> _zipFileCache = new Dictionary<string, CachedZipFile>();
        private static readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly IDataProvider _dataProvider;
        private readonly Timer _cacheCleaner;

        /// <summary>
        /// Property indicating the data is temporary in nature and should not be cached.
        /// </summary>
        public bool IsDataEphemeral { get; }

        /// <summary>
        /// Constructor that sets the <see cref="IDataProvider"/> used to retrieve data
        /// </summary>
        public ZipDataCacheProvider(IDataProvider dataProvider, bool isDataEphemeral = true)
        {
            IsDataEphemeral = isDataEphemeral;
            _dataProvider = dataProvider;
            _cacheCleaner = new Timer(state => CleanCache(), null, TimeSpan.FromSeconds(CacheSeconds), Timeout.InfiniteTimeSpan);
        }

        /// <summary>
        /// Does not attempt to retrieve any data
        /// </summary>
        public Stream Fetch(string key)
        {
            string entryName = null; // default to all entries
            var filename = key;
            var hashIndex = key.LastIndexOf("#", StringComparison.Ordinal);
            if (hashIndex != -1)
            {
                entryName = key.Substring(hashIndex + 1);
                filename = key.Substring(0, hashIndex);
            }

            // handles zip files
            if (filename.EndsWith(".zip"))
            {
                Stream stream = null;

                try
                {
                    _cacheLock.EnterReadLock();
                    if (_zipFileCache.TryGetValue(filename, out var existingEntry))
                    {
                        _cacheLock.ExitReadLock();
                        if (existingEntry.EntryCache.TryGetValue(entryName, out var entry))
                        {
                            stream = CreateStream(existingEntry, entry);
                        }
                    }
                    else
                    {
                        _cacheLock.ExitReadLock();
                        _cacheLock.EnterWriteLock();
                        stream = CacheAndCreateStream(filename, entryName);
                        _cacheLock.ExitWriteLock();
                    }

                    return stream;
                }
                catch (Exception err)
                {
                    Log.Error(err, "Inner try/catch");
                    stream?.DisposeSafely();
                    return null;
                }
            }
            else
            {
                // handles text files
                return _dataProvider.Fetch(filename);
            }
        }

        /// <summary>
        /// Store the data in the cache. Not implemented in this instance of the IDataCacheProvider
        /// </summary>
        /// <param name="key">The source of the data, used as a key to retrieve data in the cache</param>
        /// <param name="data">The data as a byte array</param>
        public void Store(string key, byte[] data)
        {
            //
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            // stop the cache cleaner timer
            _cacheCleaner.DisposeSafely();
        }

        /// <summary>
        /// Remove items in the cache that are older than the cutoff date
        /// </summary>
        private void CleanCache()
        {
            var utcNow = DateTime.UtcNow;
            try
            {
                var clearCacheIfOlderThan = utcNow.AddSeconds(-CacheSeconds);
                // clean all items that that are older than CacheSeconds than the current date
                _cacheLock.EnterReadLock();
                var zipFiles = _zipFileCache.ToList();
                _cacheLock.ExitReadLock();
                
                foreach (var zip in zipFiles)
                {
                    if (zip.Value.Uncache(clearCacheIfOlderThan) == true)
                    {
                        _cacheLock.EnterWriteLock();
                        
                        // only clear items if they are not being used
                        _zipFileCache.Remove(zip.Key, out _);
                        
                        _cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                try
                {
                    _cacheCleaner.Change(TimeSpan.FromSeconds(CacheSeconds), Timeout.InfiniteTimeSpan);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private Stream CacheAndCreateStream(string filename, string entryName)
        {
            Stream stream = null;
            var dataStream = _dataProvider.Fetch(filename);

            if (dataStream != null)
            {
                try
                {
                    var newItem = new CachedZipFile(dataStream, DateTime.UtcNow);

                    newItem.EntryCache.TryGetValue(entryName, out var entry);
                    stream = CreateStream(newItem, entry);

                    _zipFileCache[filename] = newItem;
                }
                catch (Exception exception)
                {
                    if (exception is ZipException || exception is ZlibException)
                    {
                        Log.Error("ZipDataCacheProvider.Fetch(): Corrupt zip file/entry: " + filename + "#" + entryName + " Error: " + exception);
                    }
                    else throw;
                }
            }
            return stream;
        }

        /// <summary>
        /// Create a stream of a specific ZipEntry
        /// </summary>
        /// <param name="zipFile">The zipFile containing the zipEntry</param>
        /// <param name="entryName">The name of the entry</param>
        /// <param name="fileName">The name of the zip file on disk</param>
        /// <returns>A <see cref="Stream"/> of the appropriate zip entry</returns>
        private Stream CreateStream(CachedZipFile zipFile, byte[] entry)
        {
            if (entry == null)
            {
                entry = zipFile.EntryCache.FirstOrDefault().Value;
            }
            
            if (entry != null)
            {
                return new MemoryStream(entry);
            }

            return null;
        }


        /// <summary>
        /// Type for storing zipfile in cache
        /// </summary>
        private class CachedZipFile
        {
            private readonly DateTime _dateCached;

            /// <summary>
            /// Contains all entries of the zip file by filename
            /// </summary>
            public readonly Dictionary<string, byte[]> EntryCache = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

            /// <summary>
            /// Initializes a new instance of the <see cref="CachedZipFile"/>
            /// </summary>
            /// <param name="dataStream">Stream containing the zip file</param>
            /// <param name="utcNow">Current utc time</param>
            public CachedZipFile(Stream dataStream, DateTime utcNow)
            {
                var zipFile = ZipFile.Read(dataStream);
                
                foreach (var entry in zipFile.Entries)
                {
                    var buf = new byte[entry.UncompressedSize];
                    var ms = new MemoryStream(buf);
                    entry.Extract(ms);
                    EntryCache[entry.FileName] = buf;
                }
                
                _dateCached = utcNow;
                dataStream.Dispose();
                zipFile.Dispose();
            }

            /// <summary>
            /// Method used to check if this object was created before a certain time
            /// </summary>
            /// <param name="date">DateTime which is compared to the DateTime this object was created</param>
            /// <returns>Bool indicating whether this object is older than the specified time</returns>
            public bool Uncache(DateTime date)
            {
                return _dateCached < date;
            }
        }
    }
}
