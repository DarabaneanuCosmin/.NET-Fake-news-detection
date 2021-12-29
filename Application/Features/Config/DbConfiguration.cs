using Microsoft.Extensions.Configuration;

namespace WebAPI.Features.Config
{
    public class DbConfiguration
    {
        private IConfiguration Configuration { get; set; }
        protected string ConnectionString;

        public DbConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ConnectionString = this.Configuration["ConnectionStrings:Default"];
        }
    }
}
