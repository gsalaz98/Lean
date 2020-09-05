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
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using QuantConnect.Interfaces;
using QuantConnect.Packets;

namespace QuantConnect.Lean.Engine.Results
{
    /// <summary>
    /// Result handler that displays BacktestResult packets in a Terminal User Interface (TUI)
    /// </summary>
    public class TUIBacktestingResultHandler : BacktestingResultHandler, IDisposable
    {
        /// <summary>
        /// Handle to the TUI application
        /// </summary>
        public IntPtr TUIHandle { get; set; }

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr initialize(string dateFormat);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void trace(IntPtr handle, string msg);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void error(IntPtr handle, string msg);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void update(IntPtr handle, string backtestResult);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void free(IntPtr handle);

        private const string DefaultDateFormat = "yyyyMMdd HH:mm:ss.fff";
        private readonly string _dateFormat;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public TUIBacktestingResultHandler() : base()
        {
            _dateFormat = DefaultDateFormat;

            Console.SetOut(new TUITextWriter(TUIHandle, _dateFormat));
            Console.SetError(new TUITextWriter(TUIHandle, _dateFormat));

            TUIHandle = initialize(_dateFormat);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            free(TUIHandle);
        }

        /// <summary>
        /// Sends the packet to the MessagingHandler and the TUI
        /// </summary>
        /// <param name="packet"></param>
        protected override void SendPacket(Packet packet)
        {
            if (packet.Type == PacketType.BacktestResult)
            {
                Update(packet);
            }

            base.SendPacket(packet);
        }

        /// <summary>
        /// Updates the TUI with a packet
        /// </summary>
        /// <param name="packet"></param>
        private void Update(Packet packet)
        {
            var packetString = JsonConvert.SerializeObject(packet);
            update(TUIHandle, packetString);
        }

        private class TUITextWriter : TextWriter
        {
            private readonly IntPtr _tuiHandle;
            private readonly string _dateFormat;

            public TUITextWriter(IntPtr handle, string dateFormat)
            {
                _tuiHandle = handle;
                _dateFormat = dateFormat;
            }

            public override void Write(string text)
            {
                trace(_tuiHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " Trace:: " + text);
            }

            public override Encoding Encoding { get; } = Encoding.UTF8;
        }
    }
}
