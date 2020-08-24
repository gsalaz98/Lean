

using QuantConnect.Packets;
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
        private readonly IntPtr _tuiHandle;
        private readonly string _dateFormat;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantConnect.Logging.ConsoleLogHandler"/> class.
        /// </summary>
        /// <param name="dateFormat">Specifies the date format to use when writing log messages to the console window</param>
        public TUILogHandler()
        {
            _dateFormat = DefaultDateFormat;
            _tuiHandle = initialize(_dateFormat);
        }

        public void Update(string packet)
        {
            update(_tuiHandle, packet);
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text">The error text to log</param>
        public void Error(string text)
        {
            error(_tuiHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " ERROR:: " + text);
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The debug text to log</param>
        public void Debug(string text)
        {
            trace(_tuiHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " DEBUG:: " + text);
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text">The trace text to log</param>
        public void Trace(string text)
        {
            trace(_tuiHandle, DateTime.Now.ToString(_dateFormat, CultureInfo.InvariantCulture) + " Trace:: " + text);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            free(_tuiHandle);
        }
    }
}

