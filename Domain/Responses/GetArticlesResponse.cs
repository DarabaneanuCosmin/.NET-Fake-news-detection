using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Responses
{
    public class GetArticlesResponse
    {
        public List<ArticleResponse> articles { get; set; }

        public bool error { get; set; }
    }
}
