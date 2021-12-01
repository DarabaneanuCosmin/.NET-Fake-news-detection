using WebAPI.Features.Queries;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Queries;
using System;

namespace WebAPI.Services
{
    public class GetArticlesService
    {
        GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler;
        GetArticlesBuilder builder;
        GetUserIdByUserTokenHandler getUserIdByUserTokenHandler;

        public GetArticlesService(
            [FromService] GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler,
            [FromService] GetArticlesBuilder builder,
            [FromService] GetUserIdByUserTokenHandler getUserIdByUserTokenHandler)
        {
            this.getArticlesByUserIdQueryHandler = getArticlesByUserIdQueryHandler;
            this.builder = builder;
            this.getUserIdByUserTokenHandler = getUserIdByUserTokenHandler;
        }

        public GetArticlesResponse GetArticles(string token)
        {
            
            byte[] id = getUserIdByUserTokenHandler.GetUserIdByUserToken(token); 
            Guid user_id = Guid.Parse(System.Text.Encoding.UTF8.GetString(id)); 
            GetArticlesByUserIdQuery getArticlesByUserIdQuery = new GetArticlesByUserIdQuery(user_id);
            List<Article> articles = getArticlesByUserIdQueryHandler.GetArticlesByUserId(getArticlesByUserIdQuery);

            return this.builder.builder(articles);
        }
    }
}
