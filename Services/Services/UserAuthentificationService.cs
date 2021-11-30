using Application.Features.Commands;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authentication;
using System;
using WebAPI.Assemblers;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public class UserAuthentificationService
    {
        InsertUserCommandHandler insertUserCommandHandler;
        AuthentificationAssembler assembler;
        public UserAuthentificationService([FromService] InsertUserCommandHandler insertUserCommandHandler, [FromService] AuthentificationAssembler assembler)
        {
            this.insertUserCommandHandler = insertUserCommandHandler;
            this.assembler = assembler;
        }
        public AuthenticationResponse SignIn(InsertUserCommand user)
        {
            var token = generateToken(user.email_address);
            var error = insertUserCommandHandler.insertUserDataAsync(user, token);
            return this.assembler.response(token, error);
        }

        public string generateToken(string email)
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
