using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using svnTrack.Core.Logging;
using svnTrack.Core.Extensions;

namespace svnTrack.Core.Preferences
{
    /// <summary>
    /// This class is a provider to read/write preferences to the ConfigurationManager
    /// </summary>
    public static class PreferencesHelper
    {
        /// <summary>
        /// This method gets a value from the configurationfile
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qualifier"></param>
        /// <param name="optionName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetPreference<T>(Type qualifier, string optionName, T defaultValue)
        {
            var key = nameof(qualifier) + ":" + optionName;

            object result = null;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key].DeserializeFromXmlString(typeof(T));
            }
            catch (ConfigurationErrorsException)
            {
                LoggerFactory.GetLogger().WriteMessage("Preferences", LogLevel.ERROR, "Error reading app settings");
            }

            if (result == null)
                return defaultValue;

            return (T)result;
        }

        /// <summary>
        /// This method sets/creates a value from the configurationfile
        /// </summary>
        /// <param name="qualifier"></param>
        /// <param name="optionName"></param>
        /// <param name="value"></param>
        public static void SetPreference(Type qualifier, string optionName, object value)
        {
            var key = nameof(qualifier) + ":" + optionName;

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value.SerializeToXmlString());
                }
                else
                {
                    settings[key].Value = value.SerializeToXmlString();
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                LoggerFactory.GetLogger().WriteMessage("Preferences", LogLevel.ERROR, "Error writing app settings");
            }
        }

    }
}
