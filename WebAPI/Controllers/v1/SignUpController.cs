using WebAPI.Features.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;
using WebAPI.Services;
using WebAPI.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class SignUpController : BaseController
    {
        [EnableCors]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ObjectResult PostSession([Microsoft.AspNetCore.Mvc.FromBody] InsertUserCommand user, [FromServices] IUserAuthentification userAuthentification)
        {
            if (user.email_address == null || user.password == null)
            {
                return StatusCode(StatusCodes.Status206PartialContent, new AuthenticationResponse());

            }
            return StatusCode(StatusCodes.Status200OK, userAuthentification.SignUp(user));

        }
    }
}
