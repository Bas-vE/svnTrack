using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using svnTrack.Core.Preferences;

namespace svnTrack.Models.Preferences
{
    /// <summary>
    /// This is preference class for the user settings
    /// </summary>
    public class UserPreferences
    {
        public static string TestValue
        {
            get { return PreferencesHelper.GetPreference(typeof(UserPreferences), nameof(TestValue), "this is a test"); }
            set { PreferencesHelper.SetPreference(typeof(UserPreferences), nameof(TestValue), value); }
        }

        public static bool TestBool
        {
            get { return PreferencesHelper.GetPreference(typeof(UserPreferences), nameof(TestBool), true); }
            set { PreferencesHelper.SetPreference(typeof(UserPreferences), nameof(TestBool), value); }
        }

    }
}
