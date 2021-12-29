using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public static class AuthentificationBuilder
    {
        public static AuthenticationResponse Builder(string token, bool error)
        {
            var response = new AuthenticationResponse
            {
                Token = token,
                Error = error
            };
            return response;
        }
    }
}
