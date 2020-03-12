using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.IO
{
    /// <summary>
    /// this class provides extended ways to check if files and folders exists
    /// </summary>
    public static class ApplicationFile
    {
        /// <summary>
        /// Check if the application exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        /// <summary>
        /// get the full path of the application
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return System.IO.Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = System.IO.Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }
    }
}
