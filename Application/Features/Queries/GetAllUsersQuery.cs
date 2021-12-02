using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class GetAllUsersQuery: DbConfiguration
    {
        public GetAllUsersQuery(IConfiguration configuration) : base(configuration)
        {
        }

        public static async Task<string> GetArticle()
        {
            using var command = new MySqlCommand("SELECT * FROM user;", null);
            using var reader = await command.ExecuteReaderAsync();
            reader.Read();
            var value = reader.GetString(1);
            // do something with 'value'
            return value;
        }
    }
}
