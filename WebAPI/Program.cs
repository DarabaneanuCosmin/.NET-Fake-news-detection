using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using System.Web.Http;
using WebAPI.Services;
using Application.Features.Commands;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureServices((_, services) =>
                    services.AddTransient<InsertArticleCommandHandler>()
                            .AddTransient<GetArticlesByIdQueryHandler>()
                            .AddTransient<UserDataService>()
                            .AddTransient<UserAuthentificationService>()
                            .AddTransient<InsertUserCommandHandler>());
    }
}
