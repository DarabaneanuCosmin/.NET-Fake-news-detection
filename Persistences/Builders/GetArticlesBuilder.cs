
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public static class GetArticlesBuilder
    {
        public static GetArticlesResponse builder(List<ArticleResponse> articles)
        {
            var response = new GetArticlesResponse();
            response.articles = articles;
            response.error = true;
            if (articles.Count > 0)
            {
                response.error = false;
            }


            return response;
        }
    }
}
