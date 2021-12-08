using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Features.Queries;
using WebAPI.Interfaces;
using WebAPI.Responses;

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

            var result = userAuthentification.LogIn(user);
            if (result.error == true)
            {
                return StatusCode(StatusCodes.Status206PartialContent, "Email or password are wrong!");
            }
            return StatusCode(StatusCodes.Status200OK, result);

        }
    }
}
