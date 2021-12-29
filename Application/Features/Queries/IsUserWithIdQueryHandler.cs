using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class IsUserWithIdQueryHandler : DbConfiguration
    {

        public IsUserWithIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool IsUserWithId(Guid query)
        {
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.Open();

                using var command = new MySqlCommand("SELECT * FROM user WHERE user.id = " + "@id", connection);
                command.Parameters.AddWithValue("@id", query);
                MySqlDataReader rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr.GetFieldValue<byte[]>(0).Length > 0)
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
