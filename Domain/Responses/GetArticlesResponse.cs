
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Responses
{
    public class GetArticlesResponse
    {
        public List<Article> articles { get; set; }

        public bool error { get; set; }

        /*public static implicit operator HttpContent(GetArticlesResponse v)
        {
            throw new NotImplementedException();
        }*/
    }
}
