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
    public class InsertArticleBuilderTest
    {
        [Fact]
        public void builderShouldBeTypeOfInsertArticleResponse()
        {
            var result = InsertArticleBuilder.builder(true);

            Assert.IsType<InsertArticleResponse>(result);
        }
    }
}
