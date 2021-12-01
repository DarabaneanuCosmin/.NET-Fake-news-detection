using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using WebAPI.Services;
using WebAPI.Assemblers;

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
                            .AddTransient<GetArticlesByUserIdQueryHandler>()
                            .AddTransient<UserAuthentificationService>()
                            .AddTransient<InsertUserCommandHandler>()
                            .AddTransient<InsertArticleBuilder>()
                            .AddTransient<InsertUserDataService>()
                            .AddTransient<GetArticlesBuilder>()
                            .AddTransient<GetArticlesService>()
                            .AddTransient<AuthentificationBuilder>()
                            .AddTransient<GetUserAuthDataQueryHandler>()
                            .AddTransient<IsEmailUsed>()
                            .AddTransient<UpdateUserTokenCommandHandler>());
    }
}
