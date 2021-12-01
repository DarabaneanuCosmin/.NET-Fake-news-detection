
using WebAPI.Features.Commands;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;

namespace WebAPI.Services
{
    public class InsertUserDataService
    {
        /*InsertArticleCommandHandler handler;
        public UserDataService([FromServices] InsertArticleCommandHandler handler)
        {
            this.handler = handler;
        }
        public bool postData(InsertArticleCommand insert)
        {
            this.handler.InsertArticle(insert);
            return true;
        }*/

        InsertArticleCommandHandler InsertArticleCommandHandler;
        InsertArticleBuilder builder;
        IsUserWithIdQueryHandler isUserWithIdQueryHandler;
        public InsertUserDataService(
            [FromService] InsertArticleCommandHandler insertArticleCommandHandler,
            [FromService] InsertArticleBuilder builder,
            [FromService] IsUserWithIdQueryHandler isUserWithIdQueryHandler)
        {
            this.InsertArticleCommandHandler = insertArticleCommandHandler;
            this.builder = builder;
            this.isUserWithIdQueryHandler = isUserWithIdQueryHandler;
        }

        public InsertArticleResponse Insert(InsertArticleCommand article)
        {
            var error = true;
            if (isUserWithIdQueryHandler.IsUserWithId(article.id_user))
            {
                error = !InsertArticleCommandHandler.InsertArticle(article);
            }
            
            return this.builder.builder(error);
        }
    }
}
