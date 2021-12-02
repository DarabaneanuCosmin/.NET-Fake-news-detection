using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public static class AuthentificationBuilder
    {
        public static AuthenticationResponse builder(string token, bool error)
        {
            var response = new AuthenticationResponse();
            response.token = token;
            response.error = error;
            return response;
        }
    }
}
