
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public class GetArticlesBuilder
    {
        public GetArticlesResponse builder(List<Article> articles)
        {
            var response = new GetArticlesResponse();
            response.articles= articles;
            response.error = true;
            if (articles.Count > 0 )
            {
                response.error = false;
            }
      
                
            return response;
        }
    }
}
