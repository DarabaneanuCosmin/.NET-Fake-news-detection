using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class InsertUserCommand
    {
        public string email_address { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }

    }
}
