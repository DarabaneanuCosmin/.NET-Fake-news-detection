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
using WebAPI.Responses;
using WebAPI.Services;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserDataController : BaseController
    {
        public static IConfiguration AppSetting { get; }

        [EnableCors]
        [HttpPost]
        public HttpResponseMessage InsertUserData([FromBody] InsertArticleCommand insert, [FromServices] InsertUserDataService userDataService)
        {
            userDataService.Insert(insert);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [EnableCors]
        [HttpGet]
        public GetArticlesResponse GetArticlesAsync([FromQuery] String token, [FromServices] GetArticlesService articlesService)
        {
            return  articlesService.GetArticles(token);
            //return await query.GetArticlesByUserId(id);
        }

        /*public async Task<List<Article>> GetAsync([FromQuery] GetArticlesByUserIdQuery id, [FromServices] GetArticlesByUserIdQueryHandler query)
        {
            return await query.GetArticlesByUserId(id);
        }*/
    }
}
