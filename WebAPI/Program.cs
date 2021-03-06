using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using WebAPI.Services;
using Application.Features.Queries;
using WebAPI.Interfaces;
using WebAPI.Assemblers;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI
{
    [ExcludeFromCodeCoverage]
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
                            .AddTransient<UserDataService>()
                            .AddTransient<GetUserAuthDataQueryHandler>()
                            .AddTransient<IsEmailUsed>()
                            .AddTransient<UpdateUserTokenCommandHandler>()
                            .AddTransient<IsUserWithIdQueryHandler>()
                            .AddTransient<GetUserIdByUserTokenHandler>()
                            .AddScoped<IUserAuthentification, UserAuthentificationService>()
                            .AddScoped<IUserData, UserDataService>()
                            );

    }
}
