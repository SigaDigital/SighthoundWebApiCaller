using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaller.Utils
{
    public static class ConfigurationUtils
    {
        private static IConfigurationRoot _configuration;

        private static void BuildAppSettings()
        {
            if (_configuration == null) 
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                _configuration = builder.Build();
            }
        }

        public static string GetAppSettingsValue(string key) 
        {
            if (key == null || key == "")
                return "";

            if (_configuration == null)
                BuildAppSettings();

            return $"{_configuration[key]}";
        }
    }
}
