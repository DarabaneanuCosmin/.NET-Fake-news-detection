
using WebAPI.Features.Commands;
using WebAPI.Assemblers;
using WebAPI.Responses;

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
        public InsertUserDataService([FromService] InsertArticleCommandHandler insertArticleCommandHandler, [FromService] InsertArticleBuilder builder)
        {
            this.InsertArticleCommandHandler = insertArticleCommandHandler;
            this.builder = builder;
        }

        public InsertArticleResponse Insert(InsertArticleCommand article)
        {
            //IsUserWithIdQueryHandler isUserWithIdQueryHandler = [FromServiceAttribute] IsUserWithIdQueryHandler user;
            /*if (isUserWithIdQueryHandler.IsUserWithId(article.id_user))
            {

            }*/
            var error = InsertArticleCommandHandler.InsertArticle(article);
            return this.builder.builder(error);
        }
    }
}
