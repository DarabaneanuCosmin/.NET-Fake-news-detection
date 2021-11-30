using Microsoft.Extensions.Configuration;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    class DeleteArticleCommandHandler : DbConfiguration
    {
        public DeleteArticleCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
