using Application.Features.Queries;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using WebAPI.Assemblers;
using WebAPI.Controllers.v1;
using WebAPI.Features.Queries;
using WebAPI.Responses;
using WebAPI.Services;
using Xunit;

namespace Core.Test
{
    public class UserDataControllerTest
    {
        private readonly UserDataController controller;

        public UserDataControllerTest()
        {
            controller = new UserDataController();
        }

        [Fact]
        public void Given_UserDataController_When_GetArticlesIsCalled_Then_ShouldReturnA_GetArticleResponse()
        {
            //arrange
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2MzgzMjg1NTgsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.JpmP5UZ2AfOklilRPVfe7optTsHiWe-UwTBwjNeTZTg";

            //var mock = new Mock<GetArticlesService>().Object;

            //GetArticlesService getArticlesService = new GetArticlesService();

            var services = new ServiceCollection();
            services.AddTransient<GetArticlesByUserIdQueryHandler>();
            services.AddTransient<GetArticlesBuilder>();
            services.AddTransient<GetUserIdByUserTokenHandler>();

            var serviceProvider = services.BuildServiceProvider();
            //ar trb interfata la getService
            GetArticlesService getArticlesService = serviceProvider.GetService<GetArticlesService>();

            //act
            var result = controller.GetArticles(token, getArticlesService);

            //assert
            var viewResult = Assert.IsType<GetArticlesResponse>(result);
           
        }
    }
}
