using WebAPI.Features.Commands;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;
using Application.Features.Queries;
using System;
using Services.Services;
using WebAPI.Interfaces;
using System.Collections.Generic;

namespace WebAPI.Services
{
    public class UserDataService : IUserData
    {
        readonly InsertArticleCommandHandler InsertArticleCommandHandler;
        readonly IsUserWithIdQueryHandler IsUserWithIdQueryHandler;
        readonly GetUserIdByUserTokenHandler GetUserIdByUserTokenHandler;
        readonly GetArticlesByUserIdQueryHandler GetArticlesByUserIdQueryHandler;

        public UserDataService(
            [FromService] InsertArticleCommandHandler insertArticleCommandHandler,
            [FromService] IsUserWithIdQueryHandler isUserWithIdQueryHandler,
            [FromService] GetUserIdByUserTokenHandler getUserIdByUserTokenHandler,
            [FromService] GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler)
        {
            this.InsertArticleCommandHandler = insertArticleCommandHandler;
            this.IsUserWithIdQueryHandler = isUserWithIdQueryHandler;
            this.GetUserIdByUserTokenHandler = getUserIdByUserTokenHandler;
            this.GetArticlesByUserIdQueryHandler = getArticlesByUserIdQueryHandler;
            this.GetUserIdByUserTokenHandler = getUserIdByUserTokenHandler;
        }

        public InsertArticleResponse Insert(InsertArticleUsingTokenCommand insertArticleUsingTokenCommand)
        {
            var error = true;
            byte[] id = GetUserIdByUserTokenHandler.GetUserIdByUserToken(insertArticleUsingTokenCommand.Token);
            Guid user_id = Guid.Parse(System.Text.Encoding.UTF8.GetString(id));
            InsertArticleCommand article = new()
            {
                Id_user = user_id,
                Subject = insertArticleUsingTokenCommand.Subject,
                Text = insertArticleUsingTokenCommand.Text,
                Title = insertArticleUsingTokenCommand.Title,
                Date_article = insertArticleUsingTokenCommand.Date_article,
                Is_fake = insertArticleUsingTokenCommand.Is_fake
            };
            if (IsUserWithIdQueryHandler.IsUserWithId(article.Id_user))
            {
                error = !InsertArticleCommandHandler.InsertArticle(article);
            }

            return InsertArticleBuilder.Builder(error);
        }

        public GetArticlesResponse GetArticles(string token)
        {

            byte[] id = GetUserIdByUserTokenHandler.GetUserIdByUserToken(token);
            Guid user_id = Guid.Parse(System.Text.Encoding.UTF8.GetString(id));
            GetArticlesByUserIdQuery getArticlesByUserIdQuery = new(user_id);
            List<ArticleResponse> articles = GetArticlesByUserIdQueryHandler.GetArticlesByUserId(getArticlesByUserIdQuery);

            return GetArticlesBuilder.Builder(articles);
        }
    }
}
