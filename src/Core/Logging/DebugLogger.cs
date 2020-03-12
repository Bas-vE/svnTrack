using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Logging
{
    /// <summary>
    /// Driver class to adapts calls from ILogger to work with a System.Diagnostics.Debug backend
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Writes messages to the IDE Debug output.
        /// </summary>
        /// <param id="category"">A string of the category to log to</param>
        /// <param id="level"">A LogLevel value of the level of the log</param>
        /// <param id="message"">A String of the message to write to the log</param>
        public void WriteMessage(string category, LogLevel level, string message)
        {
            Debug.WriteLine(Enum.GetName(typeof(LogLevel), level) + " [" + category + "] " + message);
        }
    }
}
