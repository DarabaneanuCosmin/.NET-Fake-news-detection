using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class GetArticlesByIdQueryHandler: DbConfiguration
    {
        public MySqlConnection connection;

        public GetArticlesByIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<string> GetArticle()
        {
            this.connection = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionStrings:Default"]);
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM user;", this.connection);
            using var reader = await command.ExecuteReaderAsync();
            reader.Read();
            var value = reader.GetString(1);
            // do something with 'value'
            return value;
        }
    }
}
