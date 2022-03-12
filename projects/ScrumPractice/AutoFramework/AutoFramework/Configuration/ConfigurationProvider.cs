using System;
using System.IO;
using AutoFramework.Constants;
using Microsoft.Extensions.Configuration;

namespace AutoFramework.Configuration
{
    public static class ConfigurationProvider
    {
        public static IConfiguration GetConfigurationValue { get; }

        static ConfigurationProvider()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            GetConfigurationValue = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetCurrentDirectory()}/{AppConstants.ConfigurationFolderName}")
                .AddJsonFile(AppConstants.AppConfigJsonFileName)
                .Build();
        }
    }
}