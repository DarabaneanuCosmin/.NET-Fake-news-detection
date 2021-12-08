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
using WebAPI.Interfaces;
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
        public HttpResponseMessage InsertUserData([FromBody] InsertArticleUsingTokenCommand insert, [FromServices] IUserData userData)
        {
            userData.Insert(insert);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [EnableCors]
        [HttpGet]
        public GetArticlesResponse GetArticles([FromQuery] String token, [FromServices] IUserData userData)
        {
            return userData.GetArticles(token);
        }
    }
}
