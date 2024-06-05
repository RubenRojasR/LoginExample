using Microsoft.Extensions.Configuration;
using System.IO;

namespace LoginExample.Helpers
{
    public class Configuration
    {
        private static IConfiguration ConfigurationManager => 
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        public static string GetConnectionString(string name) =>
            ConfigurationManager.GetConnectionString(name);

        public static string Get(string key) => 
            ConfigurationManager[key];
    }
}
