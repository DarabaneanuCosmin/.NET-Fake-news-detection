using Microsoft.Extensions.Configuration;
using System;
using WebAPI.Features.Commands;
using Xunit;

namespace Core.Test
{
    
    public class InsertArticleCommandHandlerTest
    {
        private readonly InsertArticleCommandHandler insertArticleCommandHandler;

        public InsertArticleCommandHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
        }

        [Fact]
        public void Insert_Article_Should_Return_True()
        {
            InsertArticleCommand article = new()
            {
                Id_user = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Title = "titlu articol",
                Text = "acest text este continutul articolului",
                Subject = "divertisment",
                Date_article = "01/12/2021"
            };

            var result = insertArticleCommandHandler.InsertArticle(article);

            Assert.True(result);
        }
    }
}
