
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Responses
{
    public class GetArticlesResponse
    {
        public List<Article> articles { get; set; }

        public bool error { get; set; }
    }
}
