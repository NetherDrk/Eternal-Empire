using UnityEngine;

namespace Assets.Plugins
{
    public static class PlayerPrefs2 {

        // Set and Get Double

        public static void SetDouble(string key, double value)
        {
            PlayerPrefs.SetString(key, DoubleToString(value));
        }
        public static double GetDouble(string key, double defaultValue)
        {
            var defaultVal = DoubleToString(defaultValue);
            return StringToDouble(PlayerPrefs.GetString(key, defaultVal));
        }

        private static string DoubleToString(double target)
        {
            return target.ToString("R");
        }
        private static double StringToDouble(string target)
        {
            return string.IsNullOrEmpty(target) ? 0d : double.Parse(target);
        }

        // Set and Get Ulong

        public static void SetUlong(string key, ulong value)
        {
            PlayerPrefs.SetString(key, UlongToString(value));
        }
        public static ulong GetUlong(string key, ulong defaultValue)
        {
            var defaultVal = UlongToString(defaultValue);
            return StringToUlong(PlayerPrefs.GetString(key, defaultVal));
        }
        private static string UlongToString(ulong target)
        {
            return target.ToString();
        }
        private static ulong StringToUlong(string target)
        {
            return string.IsNullOrEmpty(target) ? 0 : ulong.Parse(target);
        }

        // Set and Get Bool
        public static void SetBool(string name, bool booleanValue) 
        {
            PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
        }

        public static bool GetBool(string name, bool defaultValue)
        {
            if (PlayerPrefs.HasKey(name)) 
            {
                return PlayerPrefs.GetInt(name) == 1;
            }

            return defaultValue;
        }
    }
}
