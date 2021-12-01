using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Queries;

namespace WebAPI.Features.Collections
{
    public class Collection
    {
        public bool error { get; set; }
        public GetArticlesByUserIdQuery[] getArticles { get; set; }
    }
}
