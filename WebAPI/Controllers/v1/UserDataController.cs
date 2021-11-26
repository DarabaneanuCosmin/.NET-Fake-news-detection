using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebAPI.Entities;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserDataController: BaseController
    {
        public static IConfiguration AppSetting { get; }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> GetAsync(int id)
        {
           
           return Enumerable.Range(1, 1).Select(index => new Article
            {

                Title = "As U.S. budget fight looms, Republicans flip their fiscal script",
                Text = "WASHINGTON (Reuters) - The head of a conservative Republican faction in the U.S. Congress, who voted...",
                Subject = "politicsNews",
                Date = new DateTime(2017,12,31)
            }).ToArray();
        }
    }
}