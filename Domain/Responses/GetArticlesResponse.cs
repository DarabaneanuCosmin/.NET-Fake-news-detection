using System.Collections.Generic;

namespace WebAPI.Responses
{
    public class GetArticlesResponse
    {
        public List<ArticleResponse> Articles { get; set; }

        public bool Error { get; set; }
    }
}
