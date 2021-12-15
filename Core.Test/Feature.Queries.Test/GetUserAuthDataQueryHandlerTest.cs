using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WebAPI.Features.Config;
using WebAPI.Features.Queries;
using WebAPI.Responses;
using Xunit;

namespace Core.Test.Feature.Queries.Test
{
    public class GetUserAuthDataQueryHandlerTest
    {
        private readonly GetUserAuthDataQueryHandler getUserAuthDataQueryHandler;

        public GetUserAuthDataQueryHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
        }

        [Fact]
        public void IsUser_Should_Return_an_Update_User_Response()
        {
            GetUserAuthDataQuery getUserAuthDataQuery = new GetUserAuthDataQuery();
            getUserAuthDataQuery.email_address = "ionpop@gmail.com";
            getUserAuthDataQuery.encryptedPassword = Security.EncryptString("parola");


            var result = getUserAuthDataQueryHandler.isUser(getUserAuthDataQuery);

            Assert.IsType<UpdateUserResponse>(result);
            Assert.NotNull(result);
        }
    }
}
