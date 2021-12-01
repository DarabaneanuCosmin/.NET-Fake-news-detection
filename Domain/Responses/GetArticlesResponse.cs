
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Responses
{
    public class GetArticlesResponse
    {
        public Task<List<Article>> articles;

        public bool error { get; set; } = false;
    }
}
