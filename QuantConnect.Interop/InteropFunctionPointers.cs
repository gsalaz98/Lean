using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static QuantConnect.Interop.InteropDelegates;

namespace QuantConnect.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InteropFunctionPointers
    {
        [MarshalAs(UnmanagedType.FunctionPtr)] public ptr_SetStartDate SetStartDate;
        [MarshalAs(UnmanagedType.FunctionPtr)] public ptr_SetEndDate SetEndDate;
        [MarshalAs(UnmanagedType.FunctionPtr)] public ptr_AddEquity AddEquity;
        [MarshalAs(UnmanagedType.FunctionPtr)] public ptr_History History;
    }
}
