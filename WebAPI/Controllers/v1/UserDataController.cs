using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Entities;
using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserDataController : BaseController
    {
        public static IConfiguration AppSetting { get; }

        [EnableCors]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] InsertArticleCommand insert, [FromServices] InsertArticleCommandHandler handler)
        {
            handler.InsertArticle(insert);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [EnableCors]
        [HttpGet]
        public async Task<string> GetAsync(int id, [FromServices] GetArticlesByIdQueryHandler query)
        {
            return await query.GetArticle();
            /*return Enumerable.Range(1, 1).Select(index => new Article
            {

                Title = "As U.S. budget fight looms, Republicans flip their fiscal script",
                Text = "WASHINGTON (Reuters) - The head of a conservative Republican faction in the U.S. Congress, who voted...",
                Subject = "politicsNews",
                Date = new DateTime(2017, 12, 31)
            }).ToArray();*/
        }
    }
}
