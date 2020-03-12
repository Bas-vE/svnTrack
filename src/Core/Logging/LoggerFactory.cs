using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Logging
{
    public class LoggerFactory
    {
        // reference to the ILogger object.  Get a reference the first time then keep it
        private static ILogger logger;

        // This variable is used as a lock for thread safety
        private static object lockObject = new object();

        public static ILogger GetLogger()
        {
            lock (lockObject)
            {
                if (logger == null)
                {
                    string class_name = ConfigurationManager.AppSettings["Logger.ClassName"];

                    if (String.IsNullOrEmpty(class_name))
                        throw new ApplicationException("Missing config data for Logger");

                    Assembly assembly = Assembly.GetAssembly(typeof(LoggerFactory));
                    logger = assembly.CreateInstance(class_name) as ILogger;

                    if (logger == null)
                        throw new ApplicationException(
                            string.Format("Unable to instantiate ILogger class {0}", class_name));
                }
                return logger;
            }
        }
    }
}
