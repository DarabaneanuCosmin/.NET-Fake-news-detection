using Microsoft.Extensions.Configuration;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class CreateArticleCommandHandler : DbConfiguration
    {
        public CreateArticleCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
