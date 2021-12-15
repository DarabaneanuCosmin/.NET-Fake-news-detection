using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Features.Config
{
    public class DbConfiguration
    {
        private IConfiguration configuration { get; set; }
        protected string connectionString;

        public DbConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration["ConnectionStrings:Default"];
        }
    }
}
