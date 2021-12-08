using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
            if (insert.token != null)
            {
                userData.Insert(insert);

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        [EnableCors]
        [HttpGet]
        public ObjectResult GetArticles([FromQuery] String token, [FromServices] IUserData userData)
        {
            if (token == null || token == string.Empty)
            {
                return StatusCode(StatusCodes.Status206PartialContent, new GetArticlesResponse());

            }
            return StatusCode(StatusCodes.Status206PartialContent, userData.GetArticles(token));
        }
    }
}
