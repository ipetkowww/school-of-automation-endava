using ExamBasicAutomation.Constants;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ExamBasicAutomation.Configuration
{
    public static class ConfigurationProvider
    {
        public static IConfiguration GetConfigValue { get; }

        static ConfigurationProvider()
        {
            GetConfigValue = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetCurrentDirectory()}\\{AppConstants.ConfigFolderName}")
                .AddJsonFile(AppConstants.AppConfigurationJsonFileName)
                .Build();
        }
    }
}
