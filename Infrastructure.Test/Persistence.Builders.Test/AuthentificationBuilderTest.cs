using System;
using WebAPI.Assemblers;
using WebAPI.Responses;
using Xunit;

namespace Infrastructure.Test
{
    public class AuthentificationBuilderTest
    {
        [Fact]
        public void builderShouldBeTypeOfAuthenticationResponse()
        {
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2Mzg5ODQwMDQsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.kyRY - 8BBYtA2MpVJg8cBT08x_ZO_Napx9IyYX76ATxk"; 
            bool error = false;

            var result =AuthentificationBuilder.builder(token, error);

            Assert.IsType<AuthenticationResponse>(result);
        }
    }
}
