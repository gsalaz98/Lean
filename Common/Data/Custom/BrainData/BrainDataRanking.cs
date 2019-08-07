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

using QuantConnect.Interfaces;
using System;

namespace QuantConnect.Data.Custom.BrainData
{
    public class BrainDataRanking : BaseData, IDataConvertable
    {
        public BrainDataRanking()
        {
        }

        /// <summary>
        /// Constructor populates fields from formatted CSV data contained inside the Data folder
        /// </summary>
        /// <param name="line">Formatted CSV line</param>
        public void FromData(string line)
        {
        }

        public void FromRawData(string line)
        {
            throw new NotImplementedException();
        }

        public string ToLine()
        {
            throw new NotImplementedException();
        }

        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException();
        }

        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            throw new NotImplementedException();
        }
    }
}
