using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    class GetArticlesByIdQueryHandler
    {
        public async Task<string> GetArticle()
        {
            using var connection = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionStrings:Default"]);
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM user;", connection);
            using var reader = await command.ExecuteReaderAsync();
            reader.Read();
            var value = reader.GetString(1);
            // do something with 'value'
            return value;
        }
    }
}
