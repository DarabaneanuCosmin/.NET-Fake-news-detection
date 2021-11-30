using System;

namespace WebAPI.Entities
{
    public class Session
    {
        public Guid id { get; set; }

        public string Token { get; set; }

        public string Email_address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
