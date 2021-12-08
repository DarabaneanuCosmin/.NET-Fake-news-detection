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

            var result = isEmailUsed.isUsed(email_address);

            Assert.IsType<bool>(result);
        }
    }
}
