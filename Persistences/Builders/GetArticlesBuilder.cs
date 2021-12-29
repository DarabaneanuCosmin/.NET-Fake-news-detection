using System.Collections.Generic;
using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public static class GetArticlesBuilder
    {
        public static GetArticlesResponse Builder(List<ArticleResponse> articles)
        {
            var response = new GetArticlesResponse
            {
                Articles = articles,
                Error = true
            };
            if (articles.Count > 0)
            {
                response.Error = false;
            }

            return response;
        }
    }
}
