using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigContrib
{
    public static class AppSettings
    {
        // Default type of T
        private static T GetDefaultType<T>(string value)
        {
            if (value == null)
                return default(T);

            try
            {
                var valueConverted = (T)Convert.ChangeType(value, typeof(T));
                return valueConverted;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error converting {value} to {typeof(T)}", ex);
            }
        }

        public static T Get<T>(string name)
        {
            return Get<T>(name, default(T));
        }

        /// <summary>
        /// Get a value from config or environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="fallbackValue">What return type if the key does not found</param>
        /// <returns></returns>
        public static T Get<T>(string name, T fallbackValue)
        {
            try
            {
                if (GetConfig(name) != null)
                {
                    return GetConfig<T>(name);
                }
                else if (GetEnviromentUser(name) != null)
                {
                    return GetEnviromentUser<T>(name);
                }
                else if (GetEnviromentMachine(name) != null)
                {
                    return GetEnviromentMachine<T>(name);
                }
                else if (GetEnviromentProcess(name) != null)
                {
                    return GetEnviromentProcess<T>(name);
                }
                else
                {
                    return fallbackValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting AppSettings Key: {name}", ex);
            }
        }

        public static T GetConfig<T>(string name)
        {
            return GetDefaultType<T>(GetConfig(name));
        }

        public static string GetConfig(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        public static T GetEnviromentMachine<T>(string name)
        {
            return GetDefaultType<T>(GetEnviromentMachine(name));
        }

        public static string GetEnviromentMachine(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
        }

        public static T GetEnviromentProcess<T>(string name)
        {
            return GetDefaultType<T>(GetEnviromentProcess(name));
        }

        public static string GetEnviromentProcess(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }

        public static T GetEnviromentUser<T>(string name)
        {
            return GetDefaultType<T>(GetEnviromentUser(name));
        }

        public static string GetEnviromentUser(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
        }
    }
}