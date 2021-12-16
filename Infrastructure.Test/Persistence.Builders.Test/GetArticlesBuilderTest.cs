using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Assemblers;
using WebAPI.Responses;
using Xunit;

namespace Infrastructure.Test.Persistence.Builders.Test
{
    public class GetArticlesBuilderTest
    {
        [Fact]
        public void builderShouldBeTypeOfGetArticlesResponse()
        {
            List<ArticleResponse> articles = new List<ArticleResponse>();

            var result = GetArticlesBuilder.builder(articles);

            Assert.IsType<GetArticlesResponse>(result);
            
        }

        [Fact]
        public void builderErrorShouldBeTrueWhenArticlesListIsEmpty()
        {
            var articles = new List<ArticleResponse>();

            var result = GetArticlesBuilder.builder(articles);

            Assert.True(result.error);
        }

        [Fact]
        public void builderErrorShouldBeFalseWhenArticlesListIsNotEmpty()
        {
            var articles = new List<ArticleResponse>();
            articles.Add(new ArticleResponse());

            var result = GetArticlesBuilder.builder(articles);

            Assert.False(result.error);
        }
    }
}
