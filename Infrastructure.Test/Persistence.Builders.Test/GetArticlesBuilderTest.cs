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
        public void BuilderShouldBeTypeOfGetArticlesResponse()
        {
            List<ArticleResponse> articles = new();

            var result = GetArticlesBuilder.Builder(articles);

            Assert.IsType<GetArticlesResponse>(result);
            
        }

        [Fact]
        public void BuilderErrorShouldBeTrueWhenArticlesListIsEmpty()
        {
            var articles = new List<ArticleResponse>();

            var result = GetArticlesBuilder.Builder(articles);

            Assert.True(result.Error);
        }

        [Fact]
        public void BuilderErrorShouldBeFalseWhenArticlesListIsNotEmpty()
        {
            var articles = new List<ArticleResponse>
            {
                new ArticleResponse()
            };

            var result = GetArticlesBuilder.Builder(articles);

            Assert.False(result.Error);
        }
    }
}
