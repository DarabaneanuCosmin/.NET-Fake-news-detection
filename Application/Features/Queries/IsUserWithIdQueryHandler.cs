using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class IsUserWithIdQueryHandler : DbConfiguration
    {
        public MySqlConnection connection;

        public IsUserWithIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> IsUserWithId(IsUserWithIdQuery query)
        {
            var articles = new List<Article>();
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                await connection.OpenAsync();

                using var command = new MySqlCommand("SELECT COUNT(*) FROM user WHERE user.id = " + "@id", this.connection);
                command.Parameters.AddWithValue("@id", query.User_id);
                MySqlDataReader rdr = command.ExecuteReader();
                while (await rdr.ReadAsync())
                {
                    articles.Add(new Article()
                    {
                        Id = await rdr.GetFieldValueAsync<int>(0),
                        //Id_user = await rdr.GetFieldValueAsync<Guid>(1),
                        Title = await rdr.GetFieldValueAsync<String>(2),
                        Text = await rdr.GetFieldValueAsync<String>(3),
                        Subject = await rdr.GetFieldValueAsync<String>(4),
                        Date_article = await rdr.GetFieldValueAsync<String>(5)
                    });

                }
                while (await rdr.ReadAsync())
                {
                    if (await rdr.GetFieldValueAsync<int>(0) == 1)
                        return true;
                    return false;
                }
                rdr.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }
    }
}
