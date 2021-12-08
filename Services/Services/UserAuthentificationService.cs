using WebAPI.Features.Commands;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authentication;
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
        GetUserAuthDataQueryHandler GetUserAuthDataQueryHandler { get; set; }
        InsertUserCommandHandler insertUserCommandHandler { get; set; }
        IsEmailUsed isEmailUsed { get; set; }
        UpdateUserTokenCommandHandler updateUserTokenCommandHandler { get; set; }
        public UserAuthentificationService(
            [FromService] InsertUserCommandHandler insertUserCommandHandler,
            [FromService] GetUserAuthDataQueryHandler getUserAuthDataQueryHandler,
            [FromService] IsEmailUsed isEmailUsed,
            [FromService] UpdateUserTokenCommandHandler updateUserTokenCommandHandler
            )
        {
            this.insertUserCommandHandler = insertUserCommandHandler;
            this.GetUserAuthDataQueryHandler = getUserAuthDataQueryHandler;
            this.isEmailUsed = isEmailUsed;
            this.updateUserTokenCommandHandler = updateUserTokenCommandHandler;
        }



        public AuthenticationResponse SignUp(InsertUserCommand user)
        {
            if (!isEmailUsed.isUsed(user.email_address))
            {
                var token = generateToken(user.email_address);
                var error = insertUserCommandHandler.insertUserDataAsync(user, token);
                return AuthentificationBuilder.builder(token, error);
            }
            return AuthentificationBuilder.builder("", true);
        }

        public AuthenticationResponse LogIn(GetUserAuthDataQuery userData)
        {
            var isUser = this.GetUserAuthDataQueryHandler.isUser(userData);
            bool error = true;
            var token = "";
            if (isUser.result)
            {
                error = false;
                token = generateToken(userData.email_address);
                updateUserTokenCommandHandler.updateUser(isUser.id, token);
            }
            return AuthentificationBuilder.builder(token, error);
        }

        public static string generateToken(string email)
        {
            var secret = email;
            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(secret)
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                      .AddClaim("claim2", "claim2-value")
                      .Encode();
            return token;
        }
    }
}
