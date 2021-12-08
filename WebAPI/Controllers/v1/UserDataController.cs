using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Features.Commands;
using WebAPI.Interfaces;
using WebAPI.Responses;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserDataController : BaseController
    {
        public static IConfiguration AppSetting { get; }

        [EnableCors]
        [HttpPost]
        public StatusCodeResult InsertUserData([FromBody] InsertArticleUsingTokenCommand insert, [FromServices] IUserData userData)
        {
            if (insert.token != null)
            {
                userData.Insert(insert);

                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status401Unauthorized);
        }

        [EnableCors]
        [HttpGet]
        public ObjectResult GetArticles([FromQuery] String token, [FromServices] IUserData userData)
        {
            
            if (token == null || token == string.Empty)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new GetArticlesResponse());

            }
            GetArticlesResponse articlesResponse = userData.GetArticles(token);
            if(articlesResponse.articles.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new GetArticlesResponse());
            }
            return StatusCode(StatusCodes.Status200OK, articlesResponse);
        }
    }
}
