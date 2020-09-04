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
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using QuantConnect.Logging;
using QuantConnect.Packets;

namespace QuantConnect.Lean.Engine.Results
{
    /// <summary>
    /// Result handler that displays BacktestResult packets in a Terminal User Interface (TUI)
    /// </summary>
    public class TUIBacktestingResultHandler : BacktestingResultHandler
    {
        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void update(IntPtr handle, string backtestResult);

        private readonly TUILogHandler LeanTUI;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public TUIBacktestingResultHandler() : base()
        {
            LeanTUI = TUILogHandler.Instance;
        }

        /// <summary>
        /// Sends the packet to the MessagingHandler and the TUI
        /// </summary>
        /// <param name="packet"></param>
        protected override void SendPacket(Packet packet)
        {
            base.SendPacket(packet);
            if (packet.Type == PacketType.BacktestResult)
            {
                Update(packet);
            }
        }

        /// <summary>
        /// Updates the TUI with a packet
        /// </summary>
        /// <param name="packet"></param>
        private void Update(Packet packet)
        {
            var packetString = JsonConvert.SerializeObject(packet);
            update(LeanTUI.TUIHandle, packetString);
        }
    }
}
