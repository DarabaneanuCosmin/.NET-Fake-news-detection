using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Responses;

namespace WebAPI.Assemblers
{
    public class AuthentificationBuilder
    {
        public AuthenticationResponse builder(string token, bool error)
        {
            var response = new AuthenticationResponse();
            response.token = token;
            response.error = error;
            return response;
        }
    }
}
