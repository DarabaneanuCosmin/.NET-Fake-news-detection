using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public class InsertArticleBuilder
    {
        public static InsertArticleResponse builder(bool error)
        {
            var response = new InsertArticleResponse();
            response.error = error;
            return response;
        }
    }
}
