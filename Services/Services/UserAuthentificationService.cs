using WebAPI.Features.Commands;
using JWT.Algorithms;
using JWT.Builder;
using System;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;
using Services.Services;
using WebAPI.Interfaces;

namespace WebAPI.Services
{
    public class UserAuthentificationService : IUserAuthentification
    {
        readonly GetUserAuthDataQueryHandler GetUserAuthDataQueryHandler;
        readonly InsertUserCommandHandler InsertUserCommandHandler;
        readonly IsEmailUsed IsEmailUsed;
        readonly UpdateUserTokenCommandHandler UpdateUserTokenCommandHandler;
        public UserAuthentificationService(
            [FromService] InsertUserCommandHandler insertUserCommandHandler,
            [FromService] GetUserAuthDataQueryHandler getUserAuthDataQueryHandler,
            [FromService] IsEmailUsed isEmailUsed,
            [FromService] UpdateUserTokenCommandHandler updateUserTokenCommandHandler
            )
        {
            this.InsertUserCommandHandler = insertUserCommandHandler;
            this.GetUserAuthDataQueryHandler = getUserAuthDataQueryHandler;
            this.IsEmailUsed = isEmailUsed;
            this.UpdateUserTokenCommandHandler = updateUserTokenCommandHandler;
        }

        public AuthenticationResponse SignUp(InsertUserCommand user)
        {

            if (!IsEmailUsed.IsUsed(user.Email_address))
            {
                var token = GenerateToken(user.Email_address);
                var error = InsertUserCommandHandler.InsertUserDataAsync(user, token);
                return AuthentificationBuilder.Builder(token, error);
            }
            return AuthentificationBuilder.Builder("", true);
        }

        public AuthenticationResponse LogIn(GetUserAuthDataQuery userData)
        {
            var isUser = this.GetUserAuthDataQueryHandler.IsUser(userData);
            bool error = true;
            var token = "";
            if (isUser.Result)
            {
                error = false;
                token = GenerateToken(userData.Email_address);
                UpdateUserTokenCommandHandler.UpdateUser(isUser.Id, token);
            }
            return AuthentificationBuilder.Builder(token, error);
        }

        public static string GenerateToken(string email)
        {
            var secret = email;
            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(secret)
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(3).ToUnixTimeSeconds())
                      .AddClaim("claim2", "claim2-value")
                      .Encode();
            return token;
        }
    }
}
