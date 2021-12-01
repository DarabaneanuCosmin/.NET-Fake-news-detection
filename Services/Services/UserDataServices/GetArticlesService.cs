using WebAPI.Features.Queries;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class GetArticlesService
    {
        GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler;
        GetArticlesBuilder builder;

        public GetArticlesService([FromService] GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler, [FromService] GetArticlesBuilder builder)
        {
            this.getArticlesByUserIdQueryHandler = getArticlesByUserIdQueryHandler;
            this.builder = builder;
        }

        public GetArticlesResponse GetArticles(GetArticlesByUserIdQuery user_id)
        {
            //IsUserWithIdQueryHandler isUserWithIdQueryHandler = [FromServiceAttribute] IsUserWithIdQueryHandler user;
            /*if (isUserWithIdQueryHandler.IsUserWithId(article.id_user))
            {

            }*/
            //Task<List<Article>>
            Task<List<Article>> articles = getArticlesByUserIdQueryHandler.GetArticlesByUserId(user_id);

            return this.builder.builder(articles);
        }
    }
}
