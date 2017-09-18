using System.IO;
using Microsoft.Extensions.Configuration;

namespace AD.Common.Configuration
{
    class ConfigurationFactory
    {
        public static IConfigurationRoot GetConfiguration(string envName, string path, string userSecrets)
        {
            var settingsFile = envName == "" ? "appsettings.json" : $"appsettings.{envName}.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(userSecrets);

            return builder.Build();
        }
    }
}
