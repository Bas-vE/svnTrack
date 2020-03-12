using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Logging
{
    /// <summary>
    /// Driver class to adapts calls from ILogger to write logs directly to file and the System.Diagnostics.Debug backend
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// Writes messages to the IDE Debug output.
        /// </summary>
        /// <param id="category"">A string of the category to log to</param>
        /// <param id="level"">A LogLevel value of the level of the log</param>
        /// <param id="message"">A String of the message to write to the log</param>
        public void WriteMessage(string category, LogLevel level, string message)
        {
            //create the logstring
            string logString = $"{Enum.GetName(typeof(LogLevel), level)}\t[{category}]\t{message}";

            //open/create the logfile in the logs folder
            var currentDirectory = Directory.GetCurrentDirectory();
            var dirInfo = Directory.CreateDirectory(Path.Combine(currentDirectory, "Logs"));

            using (StreamWriter w = File.AppendText(Path.Combine(dirInfo.FullName, DateTime.Now.ToString("dd-MM-yy") + ".log")))
            {
                //get the date and add it to the beginning of the line
                w.WriteLine($"{DateTime.Now.ToLongTimeString()}\t{logString}");
            }

            //write to the System.Diagnostics.Debug backend
            Debug.WriteLine(logString);
        }
    }
}
