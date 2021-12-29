using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public static class InsertArticleBuilder
    {
        public static InsertArticleResponse Builder(bool error)
        {
            var response = new InsertArticleResponse
            {
                Error = error
            };
            return response;
        }
    }
}
