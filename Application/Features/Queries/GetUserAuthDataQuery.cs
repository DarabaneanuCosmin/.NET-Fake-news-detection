using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Features.Queries
{
    public class GetUserAuthDataQuery
    {
        public string email_address { get; set; }
        public string password { get; set; }

    }
}
