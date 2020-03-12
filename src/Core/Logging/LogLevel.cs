using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Logging
{
    ///<summary>
    /// Enum defining log levels to use in the common logging interface
    /// </summary>
    public enum LogLevel
    {
        FATAL = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        VERBOSE = 4
    }
}
