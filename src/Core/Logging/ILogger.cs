using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Logging
{
    /// <summary>
    /// Defines the common logging interface specification
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes a message to the log
        /// </summary>
        /// <param id="category"">A String of the category to write to</param>
        /// <param id="level"">A LogLevel value of the level of this message</param>
        /// <param id="message"">A String of the message to write to the log</param>
        void WriteMessage(string category, LogLevel level, string message);

    }
}
