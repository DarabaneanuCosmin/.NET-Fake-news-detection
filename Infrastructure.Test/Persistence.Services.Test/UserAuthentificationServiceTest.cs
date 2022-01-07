using Microsoft.Extensions.Configuration;
using System;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using WebAPI.Responses;
using WebAPI.Services;
using Xunit;

namespace Infrastructure.Test.Persistence.Services.Test
{
    public class UserAuthentificationServiceTest
    {
        private readonly IConfigurationRoot configuration;
        public UserAuthentificationServiceTest()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }


        [Fact]    
        public void AfterInitializationAllFieldsShouldNotBeNull()
        {
            //arrange
            InsertUserCommandHandler insertUserCommandHandler = new InsertUserCommandHandler(configuration);
            GetUserAuthDataQueryHandler getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
            IsEmailUsed isEmailUsed = new IsEmailUsed(configuration);
            UpdateUserTokenCommandHandler updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);

            //act
            UserAuthentificationService userAuth = new UserAuthentificationService(insertUserCommandHandler, getUserAuthDataQueryHandler, isEmailUsed, updateUserTokenCommandHandler);

            // assert
            Assert.NotNull(userAuth);
        }

        [Fact]
        public void SignUp_ExpectTrue()
        {
            //arrange
            InsertUserCommandHandler insertUserCommandHandler = new InsertUserCommandHandler(configuration);
            GetUserAuthDataQueryHandler getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
            IsEmailUsed isEmailUsed = new IsEmailUsed(configuration);
            UpdateUserTokenCommandHandler updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);
            UserAuthentificationService userAuth = new UserAuthentificationService(insertUserCommandHandler, getUserAuthDataQueryHandler, isEmailUsed, updateUserTokenCommandHandler);

            InsertUserCommand insertUser = new InsertUserCommand();
            insertUser.Email_address = "ctlnlzr09@yahoo.com";

            //act
            AuthenticationResponse response = userAuth.SignUp(insertUser);

            //assert
            Assert.True(response.Error);
        }

        [Fact]
        public void SignUp_ExpectFalse()
        {
            //arrange
            InsertUserCommandHandler insertUserCommandHandler = new InsertUserCommandHandler(configuration);
            GetUserAuthDataQueryHandler getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
            IsEmailUsed isEmailUsed = new IsEmailUsed(configuration);
            UpdateUserTokenCommandHandler updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);
            UserAuthentificationService userAuth = new UserAuthentificationService(insertUserCommandHandler, getUserAuthDataQueryHandler, isEmailUsed, updateUserTokenCommandHandler);

            InsertUserCommand insertUser = new InsertUserCommand();
            insertUser.Email_address = "abcdf@yahoo.com";
            insertUser.First_name = "Lazar";
            insertUser.Last_name = "Catalina";
            insertUser.Password = "parola";

            //act
            AuthenticationResponse response = userAuth.SignUp(insertUser);

            //assert
            Assert.False(response.Error);
        }

        [Fact]
        public void LogIn_ExpectFalse()
        {
            //arrange
            InsertUserCommandHandler insertUserCommandHandler = new InsertUserCommandHandler(configuration);
            GetUserAuthDataQueryHandler getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
            IsEmailUsed isEmailUsed = new IsEmailUsed(configuration);
            UpdateUserTokenCommandHandler updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);
            UserAuthentificationService userAuth = new UserAuthentificationService(insertUserCommandHandler, getUserAuthDataQueryHandler, isEmailUsed, updateUserTokenCommandHandler);

            GetUserAuthDataQuery getUser = new GetUserAuthDataQuery();
            getUser.Email_address = "ctlnlzr09@yahoo.com";
            getUser.EncryptedPassword = "parolamea";
            //act
            AuthenticationResponse response = userAuth.LogIn(getUser);

            //assert
            Assert.False(response.Error);
        }

        [Fact]
        public void LogIn_ExpectTrue()
        {
            //arrange
            InsertUserCommandHandler insertUserCommandHandler = new InsertUserCommandHandler(configuration);
            GetUserAuthDataQueryHandler getUserAuthDataQueryHandler = new GetUserAuthDataQueryHandler(configuration);
            IsEmailUsed isEmailUsed = new IsEmailUsed(configuration);
            UpdateUserTokenCommandHandler updateUserTokenCommandHandler = new UpdateUserTokenCommandHandler(configuration);
            UserAuthentificationService userAuth = new UserAuthentificationService(insertUserCommandHandler, getUserAuthDataQueryHandler, isEmailUsed, updateUserTokenCommandHandler);

            GetUserAuthDataQuery getUser = new GetUserAuthDataQuery();
            getUser.Email_address = "lzr09@yahoo.com";
            getUser.EncryptedPassword = "parola";
            //act
            AuthenticationResponse response = userAuth.LogIn(getUser);

            //assert
            Assert.True(response.Error);
        }


        [Fact]
        public void GenerateToken()
        {
           
            //act
            string response = UserAuthentificationService.GenerateToken("ctlnlzr09@yahoo.com");

            //assert
            Assert.NotNull(response);
        }

    }
}





