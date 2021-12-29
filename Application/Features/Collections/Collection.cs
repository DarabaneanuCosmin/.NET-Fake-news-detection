using WebAPI.Features.Queries;

namespace WebAPI.Features.Collections
{
    public class Collection
    {
        public bool Error { get; set; }
        public GetArticlesByUserIdQuery[] GetArticles { get; set; }
    }
}
