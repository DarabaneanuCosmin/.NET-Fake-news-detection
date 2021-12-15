using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Features.Queries;
using WebAPI.Responses;
using Xunit;

namespace Core.Test.Feature.Queries.Test
{
    
    public class GetArticlesByUserIdQueryHandlerTest
    {
        private readonly GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler;
    
        public GetArticlesByUserIdQueryHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            getArticlesByUserIdQueryHandler = new GetArticlesByUserIdQueryHandler(configuration);
        }

        [Fact]
        public void Get_Articles_Should_Return_A_List_Of_ArticleResponses()
        {

            GetArticlesByUserIdQuery getArticlesByUserIdQuery = new GetArticlesByUserIdQuery(new Guid("9d7aec58-ef7b-4635-8df0-019fbfa9a821"));

            var result = getArticlesByUserIdQueryHandler.GetArticlesByUserId(getArticlesByUserIdQuery);

            Assert.IsType<List<ArticleResponse>>(result);
            Assert.NotNull(result);
        }

    }
}
