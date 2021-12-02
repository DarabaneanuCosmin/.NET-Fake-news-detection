using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Commands;
using Xunit;

namespace Core.Test
{
    public class UpdateUserTokenCommandHandlerTest
    {
        private readonly UpdateUserTokenCommandHandler updateUserTokenCommandHandler;

        public UpdateUserTokenCommandHandlerTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);
        }

        [Fact]
        public void Update_User_Token_Should_Return_False()
        {

            byte[] user_id = new Guid("9d7aec58-ef7b-4635-8df0-019fbfa9a821").ToByteArray();

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2MzgzNzAyOTYsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.Ux9MdLms9snhTHyx_q4ls9UO3TIPFWNAi_aIIr90K3Y";

            var result = updateUserTokenCommandHandler.updateUser(user_id, token);

            Assert.False(result);

        }
    }
}
