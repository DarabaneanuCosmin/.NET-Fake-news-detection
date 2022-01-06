using Application.Features.Queries;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using WebAPI.Services;
using Xunit;
using Microsoft.Extensions.Configuration;
using WebAPI.Responses;
using System;

namespace Infrastructure.Test.Persistence.Services.Test.Persistence.Services.UserDataServices.Test
{
    public class UserDataServiceTest
    {

        private readonly IConfigurationRoot configuration;
        public UserDataServiceTest()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        [Fact]
        public void AfterInitializationAllFieldsShouldNotBeNull()
        {
            //arrange 
            InsertArticleCommandHandler insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
            IsUserWithIdQueryHandler isUserWithIdQueryHandler = new IsUserWithIdQueryHandler(configuration);
            GetUserIdByUserTokenHandler getUserIdByUserTokenHandler = new GetUserIdByUserTokenHandler(configuration);
            GetArticlesByUserIdQueryHandler GetArticlesByUserIdQueryHandler = new GetArticlesByUserIdQueryHandler(configuration);
            
            //act
            UserDataService user = new UserDataService(insertArticleCommandHandler, isUserWithIdQueryHandler, getUserIdByUserTokenHandler, GetArticlesByUserIdQueryHandler);

            
            //Assert
            Assert.NotNull(user);
        }

        [Fact]
        public void InsertTest_ExpectError()
        {
            //arrange 
            InsertArticleUsingTokenCommand insertArticleUsingTokenCommand = new InsertArticleUsingTokenCommand();
            insertArticleUsingTokenCommand.Token = "1234";
            insertArticleUsingTokenCommand.Subject = "test";
            insertArticleUsingTokenCommand.Text = "text";
            insertArticleUsingTokenCommand.Title = "titlu";
            insertArticleUsingTokenCommand.Date_article = "10/10/2010";
            insertArticleUsingTokenCommand.Is_fake = true;
            InsertArticleCommandHandler insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
            IsUserWithIdQueryHandler isUserWithIdQueryHandler = new IsUserWithIdQueryHandler(configuration);
            GetUserIdByUserTokenHandler getUserIdByUserTokenHandler = new GetUserIdByUserTokenHandler(configuration);
            GetArticlesByUserIdQueryHandler GetArticlesByUserIdQueryHandler = new GetArticlesByUserIdQueryHandler(configuration);
            UserDataService user = new UserDataService(insertArticleCommandHandler, isUserWithIdQueryHandler, getUserIdByUserTokenHandler, GetArticlesByUserIdQueryHandler);


            //act
            InsertArticleResponse response = user.Insert(insertArticleUsingTokenCommand);

            //Assert
            Assert.True(response.Error);
        }

        [Fact]
        public void InsertTest_DoesntExpectError()
        {
            //arrange 
            InsertArticleUsingTokenCommand insertArticleUsingTokenCommand = new InsertArticleUsingTokenCommand();
            insertArticleUsingTokenCommand.Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2MzkxMzM1NjEsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.BVIYs3MPQ7uhOnbNpOZK_fGtmDUPgtZVa44lo0mXPy0";
            insertArticleUsingTokenCommand.Subject = "test";
            insertArticleUsingTokenCommand.Text = "text";
            insertArticleUsingTokenCommand.Title = "titlu";
            insertArticleUsingTokenCommand.Date_article = "10/10/2010";
            insertArticleUsingTokenCommand.Is_fake = true;
            InsertArticleCommandHandler insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
            IsUserWithIdQueryHandler isUserWithIdQueryHandler = new IsUserWithIdQueryHandler(configuration);
            GetUserIdByUserTokenHandler getUserIdByUserTokenHandler = new GetUserIdByUserTokenHandler(configuration);
            GetArticlesByUserIdQueryHandler GetArticlesByUserIdQueryHandler = new GetArticlesByUserIdQueryHandler(configuration);
            UserDataService user = new UserDataService(insertArticleCommandHandler, isUserWithIdQueryHandler, getUserIdByUserTokenHandler, GetArticlesByUserIdQueryHandler);


            //act
            InsertArticleResponse response = user.Insert(insertArticleUsingTokenCommand);

            //Assert
            Assert.False(response.Error);
        }

        [Fact]
        public void GetArticles_ExpectEmptyCollection()
        {
            //arrange 
            InsertArticleCommandHandler insertArticleCommandHandler = new InsertArticleCommandHandler(configuration);
            IsUserWithIdQueryHandler isUserWithIdQueryHandler = new IsUserWithIdQueryHandler(configuration);
            GetUserIdByUserTokenHandler getUserIdByUserTokenHandler = new GetUserIdByUserTokenHandler(configuration);
            GetArticlesByUserIdQueryHandler GetArticlesByUserIdQueryHandler = new GetArticlesByUserIdQueryHandler(configuration);
            UserDataService user = new UserDataService(insertArticleCommandHandler, isUserWithIdQueryHandler, getUserIdByUserTokenHandler, GetArticlesByUserIdQueryHandler);


            //act
            GetArticlesResponse response = user.GetArticles("1234");

            //Assert
            Assert.Empty(response.Articles);
        }

    }


}







