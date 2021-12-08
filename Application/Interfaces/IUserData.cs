using WebAPI.Features.Commands;
using WebAPI.Responses;

namespace WebAPI.Interfaces
{
    public interface IUserData
    {
        public GetArticlesResponse GetArticles(string token);

        public InsertArticleResponse Insert(InsertArticleUsingTokenCommand insertArticleUsingTokenCommand);

    }
}
