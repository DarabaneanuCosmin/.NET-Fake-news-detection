
using WebAPI.Features.Commands;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;
using Application.Features.Queries;
using System;

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
        GetUserIdByUserTokenHandler getUserIdByUserTokenHandler;
        public InsertUserDataService(
            [FromService] InsertArticleCommandHandler insertArticleCommandHandler,
            [FromService] InsertArticleBuilder builder,
            [FromService] IsUserWithIdQueryHandler isUserWithIdQueryHandler,
            [FromService] GetUserIdByUserTokenHandler getUserIdByUserTokenHandler)
        {
            this.InsertArticleCommandHandler = insertArticleCommandHandler;
            this.builder = builder;
            this.isUserWithIdQueryHandler = isUserWithIdQueryHandler;
            this.getUserIdByUserTokenHandler = getUserIdByUserTokenHandler;
        }

        public InsertArticleResponse Insert(InsertArticleUsingTokenCommand insertArticleUsingTokenCommand)
        {
            var error = true;
            byte[] id = getUserIdByUserTokenHandler.GetUserIdByUserToken(insertArticleUsingTokenCommand.token);
            Guid user_id = Guid.Parse(System.Text.Encoding.UTF8.GetString(id));
            InsertArticleCommand article = new InsertArticleCommand();
            article.id_user = user_id;
            article.subject = insertArticleUsingTokenCommand.subject;
            article.text = insertArticleUsingTokenCommand.text;
            article.title = insertArticleUsingTokenCommand.title;
            article.date_article = insertArticleUsingTokenCommand.date_article;
            if (isUserWithIdQueryHandler.IsUserWithId(article.id_user))
            {
                error = !InsertArticleCommandHandler.InsertArticle(article);
            }
            
            return this.builder.builder(error);
        }
    }
}
