using QuantConnect.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Interop
{
    public class InteropDelegates
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void ptr_SetStartDate(int year, int month, int day);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void ptr_SetEndDate(int year, int month, int day);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void ptr_AddEquity(string ticker, int resolution);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void ptr_History(string symbol, int periods, int resolution);

        public void AddEquityInterop(QCAlgorithm algo, string ticker, int resolution)
        {
            var actualResolution = (Resolution)resolution;
            algo.AddEquity(ticker, actualResolution);
        }
    }
}
