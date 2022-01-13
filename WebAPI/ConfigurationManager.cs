using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.Http;

namespace WebAPI
{
    [ExcludeFromCodeCoverage]
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        public static object AppSettings { get; internal set; }
        public static HttpConfiguration Config { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
