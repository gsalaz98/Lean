

using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace QuantConnect.Logging
{

    /// <summary>
    /// ILogHandler implementation that writes log output to console.
    /// </summary>
    public class TUILogHandler: ILogHandler
    {
        public static TUILogHandler Instance = new TUILogHandler();

        /// <summary>
        /// Handle to the TUI application
        /// </summary>
        public IntPtr TUIHandle { get; }

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr initialize(string dateFormat);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void trace(IntPtr handle, string msg);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void error(IntPtr handle, string msg);

        [DllImport("lean_tui.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void free(IntPtr handle);


        private const string DefaultDateFormat = "yyyyMMdd HH:mm:ss.fff";
        private readonly string _dateFormat;

        public TUILogHandler()
        {
            _dateFormat = DefaultDateFormat;
            TUIHandle = initialize(_dateFormat);
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text">The error text to log</param>
        public void Error(string text)
        {
            error(TUIHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " ERROR:: " + text);
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The debug text to log</param>
        public void Debug(string text)
        {
            trace(TUIHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " DEBUG:: " + text);
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The trace text to log</param>
        public void Trace(string text)
        {
            trace(TUIHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " Trace:: " + text);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            free(TUIHandle);
        }
    }
}

