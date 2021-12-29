using System;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Features.Config
{
    public static class Security
    {

        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static bool JWTTokenValidation(string token)
        {
            var jwthandler = new JwtSecurityTokenHandler();
            var jwttoken = jwthandler.ReadToken(token);
            var expDate = jwttoken.ValidTo;

            if (expDate < DateTime.UtcNow.AddMinutes(1))
            {
                return true;
            }
            return false;
        }
    }
}
