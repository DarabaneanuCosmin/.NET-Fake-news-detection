using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;
using WebAPI.Features.Queries;
using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Services;

namespace WebAPI.Controllers.v1
{
    [ApiController]

    public class LogInController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public ObjectResult LogIn([FromBody] GetUserAuthDataQuery user, [FromServices] IUserAuthentification userAuthentification)
        {
            if (user.email_address == null || user.encryptedPassword == null)
            {
                return StatusCode(StatusCodes.Status206PartialContent, new AuthenticationResponse());
            }

            return StatusCode(StatusCodes.Status206PartialContent, userAuthentification.LogIn(user));
        }
    }
}
