using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Web.Http;

namespace WebAPI
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        public static object AppSettings { get; internal set; }
        public static HttpConfiguration config { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
         
           

        }

    }
}
