using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class UpdateUserTokenCommandHandler : DbConfiguration
    {

        public UpdateUserTokenCommandHandler(IConfiguration configuration) : base(configuration)
        {

        }
        public bool updateUser(Byte[] id, string token)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionString);
                connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand("UPDATE USER SET token = @token WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                return false;

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
