using Microsoft.Extensions.Configuration;
using WebAPI.Features.Commands;
using Xunit;

namespace Core.Test
{
    public class InsertUserCommandHandlerTest
    {
        private readonly InsertUserCommandHandler insertUserCommandHandler;

        public InsertUserCommandHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            insertUserCommandHandler = new InsertUserCommandHandler(configuration);
        }

        [Fact]
        public void Insert_User_Should_Return_False()
        {
            InsertUserCommand user = new()
            {
                Email_address = "myemail@yopmail.com",
                First_name = "Ion",
                Last_name = "Popescu",
                Password = "mypass"
            };

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2MzgzNzAyOTYsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.Ux9MdLms9snhTHyx_q4ls9UO3TIPFWNAi_aIIr90K3Y";

            var result = insertUserCommandHandler.InsertUserDataAsync(user, token);

            Assert.False(result);

        }
    }
}
