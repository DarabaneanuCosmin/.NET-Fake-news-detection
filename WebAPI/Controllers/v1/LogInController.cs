using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Controllers.v1
{
    [ApiController]

    public class LogInController : BaseController
    {
        [EnableCors]
        [HttpGet]
        public IEnumerable<Session> GetSession(string email)
        {
            //serviciu
            return Enumerable.Range(1, 1).Select(index => new Session
            {
                Email_address = "darabaneanucosmin81@gmail.com",
                FirstName = "Cosmin",
                Token = "d1923nds4f"
            }).ToArray();
        }
    }
}
