
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace QuantConnect.Data.Custom.Sec
{
    [JsonConverter(typeof(PossibleListConverter<SecReportCollection>))]
    public class SecReportCollection
    {
        /// <summary>
        /// SEC reports sorted by date they first appeared on EDGAR archives
        /// </summary>
        [JsonExtensionData]
        public List<ISecReport> Submissions = new List<ISecReport>();
    }
}
