using WebAPI.Features.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class SignUpController : BaseController
    {
        [EnableCors]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ObjectResult PostSession
            (
            [Microsoft.AspNetCore.Mvc.FromBody] InsertUserCommand user,
            [FromServices] IUserAuthentification userAuthentification
            )
        {
            if (
                user.email_address == null ||
                user.email_address == string.Empty ||
                user.password == string.Empty ||
                user.password == null
                )
            {
                return StatusCode(StatusCodes.Status206PartialContent, "Email adress or password are empty ");

            }
            var result = userAuthentification.SignUp(user);
            if (result.error)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Email already exists!");

            }
            return StatusCode(StatusCodes.Status200OK, result);

        }
    }
}
