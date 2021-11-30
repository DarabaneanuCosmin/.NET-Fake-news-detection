using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Requests;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class UserAuthentificationController : BaseController
    {
        [EnableCors]
        [HttpGet]
        public IEnumerable<Session> GetSession(string email)
        {
            //serviciu
            return Enumerable.Range(1, 1).Select(index => new Session
            {
                Email = "darabaneanucosmin81@gmail.com",
                Username = "Cosmin",
                Token = "d1923nds4f"
            }).ToArray();
        }

        [EnableCors]
        [HttpPost]
        public UserRequest PostSession([FromBody] UserRequest user)
        {
            return user;
        }

        [EnableCors]
        [HttpPut]
        public SessionRequest PutSession([FromBody] SessionRequest sessionRequest)
        {
            return sessionRequest;
        }
    }
}
