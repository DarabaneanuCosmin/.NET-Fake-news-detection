using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Features.Commands;
using WebAPI.Features.Config;
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
        public ObjectResult InsertUserData
            (
            [FromBody] InsertArticleUsingTokenCommand insert,
            [FromServices] IUserData userData,
            [FromServices] Security security
            )
        {
            if (insert.token != null && security.JWTTokenValidation(insert.token))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid token");

            }

            userData.Insert(insert);

            return StatusCode(StatusCodes.Status201Created, "Inserted");
        }

        [EnableCors]
        [HttpGet]
        public ObjectResult GetArticles
            (
            [FromQuery] String token,
            [FromServices] IUserData userData,
             [FromServices] Security security
            )
        {
            if (token != null && security.JWTTokenValidation(token))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Invalid token");

            }
            GetArticlesResponse articlesResponse = userData.GetArticles(token);
            if (articlesResponse.articles.Count == 0)
            {
                return StatusCode(StatusCodes.Status200OK, "No data found");
            }
            return StatusCode(StatusCodes.Status200OK, articlesResponse);
        }
    }
}
