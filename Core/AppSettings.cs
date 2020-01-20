using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core
{
    public class AppSettings
    {
        public static string GetConnectionString()
        {
            var connectionString = SetJsonFile().GetSection("ConnectionStrings").GetSection("BlogDataBaseConnection").Value;
            return connectionString;
        }

        private static IConfigurationRoot SetJsonFile()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            return root;
        }
    }
}
