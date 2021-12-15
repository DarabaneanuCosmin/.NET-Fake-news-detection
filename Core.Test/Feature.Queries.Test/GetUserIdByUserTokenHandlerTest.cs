using Application.Features.Queries;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Core.Test.Feature.Queries.Test
{
    public class GetUserIdByUserTokenHandlerTest
    {
        private readonly GetUserIdByUserTokenHandler getUserIdByUserTokenHandler;

        public GetUserIdByUserTokenHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            getUserIdByUserTokenHandler = new GetUserIdByUserTokenHandler(configuration);
        }

        [Fact]
        public void GetUserIdByUserToken_Should_Return_A_Byte_Array()
        {
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzg5ODQwMDQsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.kyRY - 8BBYtA2MpVJg8cBT08x_ZO_Napx9IyYX76ATxk";

            var result = getUserIdByUserTokenHandler.GetUserIdByUserToken(token);

            Assert.IsType<Byte[]>(result);
            Assert.NotNull(result);
        }
    }
}
