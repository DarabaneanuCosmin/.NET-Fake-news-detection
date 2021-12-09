
using WebAPI.Features.Commands;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;
using Application.Features.Queries;
using System;
using Services.Services;
using WebAPI.Interfaces;
using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class UserDataService : IUserData
    {

        readonly InsertArticleCommandHandler InsertArticleCommandHandler;
        readonly IsUserWithIdQueryHandler isUserWithIdQueryHandler;
        readonly GetUserIdByUserTokenHandler getUserIdByUserTokenHandler;
        readonly GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler;

        public UserDataService(
            [FromService] InsertArticleCommandHandler insertArticleCommandHandler,
            [FromService] IsUserWithIdQueryHandler isUserWithIdQueryHandler,
            [FromService] GetUserIdByUserTokenHandler getUserIdByUserTokenHandler,
            [FromService] GetArticlesByUserIdQueryHandler getArticlesByUserIdQueryHandler)
        {
            this.InsertArticleCommandHandler = insertArticleCommandHandler;
            this.isUserWithIdQueryHandler = isUserWithIdQueryHandler;
            this.getUserIdByUserTokenHandler = getUserIdByUserTokenHandler;
            this.getArticlesByUserIdQueryHandler = getArticlesByUserIdQueryHandler;
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

            return InsertArticleBuilder.builder(error);
        }

        public GetArticlesResponse GetArticles(string token)
        {

            byte[] id = getUserIdByUserTokenHandler.GetUserIdByUserToken(token);
            Guid user_id = Guid.Parse(System.Text.Encoding.UTF8.GetString(id));
            GetArticlesByUserIdQuery getArticlesByUserIdQuery = new GetArticlesByUserIdQuery(user_id);
            List<ArticleResponse> articles = getArticlesByUserIdQueryHandler.GetArticlesByUserId(getArticlesByUserIdQuery);

            return GetArticlesBuilder.builder(articles);
        }
    }
}
