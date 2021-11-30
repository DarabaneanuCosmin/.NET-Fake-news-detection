using Microsoft.Extensions.Configuration;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    class UpdateArticleCommandHandler : DbConfiguration
    {
        public UpdateArticleCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
