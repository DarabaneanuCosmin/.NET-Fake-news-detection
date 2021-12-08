using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Queries;
using Xunit;

namespace Core.Test.Feature.Queries.Test
{
    public class IsUserWithIdQueryHandlerTest
    {
        private readonly IsUserWithIdQueryHandler isUserWithIdQueryHandler;

        public IsUserWithIdQueryHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            isUserWithIdQueryHandler = new IsUserWithIdQueryHandler(configuration);
        }

        [Fact]
        public void IsUserWithId_Should_Return_Bool()
        {
            Guid query = new Guid("457cce54-f5c9-4045-88b0-776c8e368df0");

            var result = isUserWithIdQueryHandler.IsUserWithId(query);

            Assert.IsType<bool>(result);
        }
    }
}
