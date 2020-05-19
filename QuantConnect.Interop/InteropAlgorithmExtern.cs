using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QuantConnect.Interop
{
    public unsafe class InteropAlgorithmExtern
    {
        /// <summary>
        /// Gets a handle of the unmanaged algorithm
        /// </summary>
        /// <returns>Unmanaged algorithm pointer</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "External function naming convention.")]
        [DllImport("QCInteropAlgorithm", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr init();

        /// <summary>
        /// Initializes the interop algorithm.
        /// </summary>
        /// <returns>Message containing instructions to QCAlgorithm</returns>
        [DllImport("QCInteropAlgorithm", CallingConvention = CallingConvention.StdCall)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Initialize(IntPtr unmanagedAlgorithm, ref InteropFunctionPointers ptrs);

        /// <summary>
        /// Provides data to the unmanaged algorithm
        /// </summary>
        /// <param name="message">Data</param>
        /// <returns>Message containing instructions to QCAlgorithm</returns>
        [DllImport("QCInteropAlgorithm", CallingConvention = CallingConvention.StdCall)]
        [SuppressUnmanagedCodeSecurity] // TODO: disable in production programatically
        public static extern IntPtr OnData(IntPtr unmanagedAlgorithm, ref InteropFunctionPointers ptrs, byte* message, ulong length);
    }
}
