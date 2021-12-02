using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAPI.Features.Commands;
using Xunit;

namespace Presentation.Test
{
    public class InsertArticleCommandHandlerTest
    {
        private readonly InsertArticleCommandHandler insertArticleCommandHandler;

        public InsertArticleCommandHandlerTest()
        {
            /*var services = new ServiceCollection();
            services.AddTransient<InsertArticleCommandHandler>();
            services.AddTransient<IConfiguration>();
            var serviceProvider = services.BuildServiceProvider();
            insertArticleCommandHandler = serviceProvider.GetService<InsertArticleCommandHandler>();*/
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
        }

        [Fact]
        public void Insert_Article_Should_Return_True()
        {
            InsertArticleCommand article = new InsertArticleCommand();
            article.id_user = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            article.title = "titlu articol";
            article.text = "acest text este continutul articolului";
            article.subject = "divertisment";
            article.date_article = "01/12/2021";

            var result = insertArticleCommandHandler.InsertArticle(article);

            Assert.True(result);
        }
    }
}
