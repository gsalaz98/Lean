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

namespace QuantConnect.Interfaces
{
    /// <summary>
    /// Indicates the data source can populate instance properties
    /// from raw data, formatted data, and serialize itself to a string
    /// </summary>
    public interface IDataConvertable
    {
        /// <summary>
        /// Populates instance properties from a line of formatted data
        /// </summary>
        /// <param name="line">Line of formatted data</param>
        void FromData(string line);

        /// <summary>
        /// Populates instance properties from a line of raw unformatted data
        /// </summary>
        /// <param name="line">Line of unformatted raw data</param>
        void FromRawData(string line);

        /// <summary>
        /// Converts the instance to a line of data as a string
        /// </summary>
        /// <returns>String containing data from the instance</returns>
        string ToLine();
    }
}
