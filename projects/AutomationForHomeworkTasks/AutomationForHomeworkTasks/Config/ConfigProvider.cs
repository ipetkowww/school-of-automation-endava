using AutomationForHomeworkTasks.Constants;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationForHomeworkTasks.Config
{
    public static class ConfigProvider
    {
        public static IConfiguration GetConfigValue { get; }
        public static string GetAppPages { get; }

        static ConfigProvider()
        {
            GetConfigValue = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetCurrentDirectory()}\\{StringConstants.ConfigFolderName}")
                .AddJsonFile(StringConstants.AppConfigJsonFileName)
                .Build();
        }
    }
}