using WebAPI.Features.Commands;
using WebAPI.Features.Queries;
using WebAPI.Responses;

namespace WebAPI.Interfaces
{

    public interface IUserAuthentification
    {
        public AuthenticationResponse SignUp(InsertUserCommand user);

        public AuthenticationResponse LogIn(GetUserAuthDataQuery userData);

    }
}
