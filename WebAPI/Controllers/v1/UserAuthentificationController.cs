using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Requests;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserAuthentificationController : BaseController
    {
        [HttpGet]
        public IEnumerable<Session> GetSession(string email)
        {
            return Enumerable.Range(1, 1).Select(index => new Session
            {
                Email = "darabaneanucosmin81@gmail.com",
                Username = "Cosmin",
                Token = "d1923nds4f"
            }).ToArray();
        }

        [HttpPost]
        public UserRequest PostSession([FromBody] UserRequest user)
        {
            return user;
        }

        [HttpPut]
        public SessionRequest PutSession([FromBody] SessionRequest sessionRequest)
        {
            return sessionRequest;
        }
    }
}