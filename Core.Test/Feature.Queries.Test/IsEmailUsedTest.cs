using Microsoft.Extensions.Configuration;
using WebAPI.Features.Queries;
using Xunit;

namespace Core.Test.Feature.Queries.Test
{
    public class IsEmailUsedTest
    {
        private readonly IsEmailUsed isEmailUsed;

        public IsEmailUsedTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            isEmailUsed = new IsEmailUsed(configuration);
        }

        [Fact]
        public void IsUsed_Should_Return_Bool()
        {
            string email_address = "ionpop@gmail.com";

            var result = isEmailUsed.IsUsed(email_address);

            Assert.IsType<bool>(result);
        }
    }
}
