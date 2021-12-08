using WebAPI.Features.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;
using WebAPI.Services;
using WebAPI.Interfaces;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class SignUpController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public AuthenticationResponse PostSession([FromBody] InsertUserCommand user, [FromServices] IUserAuthentification userAuthentification)
        {
            return userAuthentification.SignUp(user);
        }
    }
}
