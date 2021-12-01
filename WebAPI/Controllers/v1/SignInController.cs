using WebAPI.Features.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;
using WebAPI.Services;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class SignInController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public AuthenticationResponse PostSession([FromBody] InsertUserCommand user, [FromServices] UserAuthentificationService userAuthentificationService)
        {
            return userAuthentificationService.SignIn(user);
        }
    }
}
