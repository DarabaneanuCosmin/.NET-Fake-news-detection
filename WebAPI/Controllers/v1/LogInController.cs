using Microsoft.AspNetCore.Cors;
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
        public AuthenticationResponse LogIn([FromBody] GetUserAuthDataQuery user, [FromServices] IUserAuthentification userAuthentification)
        {
            return userAuthentification.LogIn(user);
        }
    }
}
