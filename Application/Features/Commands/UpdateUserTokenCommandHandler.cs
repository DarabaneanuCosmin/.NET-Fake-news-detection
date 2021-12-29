using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class UpdateUserTokenCommandHandler : DbConfiguration
    {

        public UpdateUserTokenCommandHandler(IConfiguration configuration) : base(configuration)
        {

        }
        public bool UpdateUser(Byte[] id, string token)
        {
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.OpenAsync();
                MySqlCommand cmd = new("UPDATE USER SET token = @token WHERE id = @id", connection);
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
