using WebAPI.Features.Commands;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authentication;
using System;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPI.Features.Queries;
using Services.Services;

namespace WebAPI.Services
{
    public class UserAuthentificationService
    {
        GetUserAuthDataQueryHandler GetUserAuthDataQueryHandler { get; set; }
        InsertUserCommandHandler insertUserCommandHandler { get; set; }
        AuthentificationBuilder builder { get; set; }
        IsEmailUsed isEmailUsed { get; set; }
        UpdateUserTokenCommandHandler updateUserTokenCommandHandler { get; set; }
        public UserAuthentificationService(
            [FromService] InsertUserCommandHandler insertUserCommandHandler,
            [FromService] AuthentificationBuilder builder,
            [FromService] GetUserAuthDataQueryHandler getUserAuthDataQueryHandler,
            [FromService] IsEmailUsed isEmailUsed,
            [FromService] UpdateUserTokenCommandHandler updateUserTokenCommandHandler
            )
        {
            this.insertUserCommandHandler = insertUserCommandHandler;
            this.builder = builder;
            this.GetUserAuthDataQueryHandler = getUserAuthDataQueryHandler;
            this.isEmailUsed = isEmailUsed;
            this.updateUserTokenCommandHandler = updateUserTokenCommandHandler;
        }
        public AuthenticationResponse SignIn(InsertUserCommand user)
        {
            if (!isEmailUsed.isUsed(user.email_address))
            {
                var token = generateToken(user.email_address);
                var error = insertUserCommandHandler.insertUserDataAsync(user, token);
                return this.builder.builder(token, error);
            }
            return this.builder.builder("", true);
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
            return this.builder.builder(token, error);
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
