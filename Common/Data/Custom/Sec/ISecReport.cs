using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Data.Custom.Sec
{
    public interface ISecReport
    {
        /// <summary>
        /// Contents of the actual SEC report
        /// </summary>
        SecReportSubmission Report { get; }
    }
}
