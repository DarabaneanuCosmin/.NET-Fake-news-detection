using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebAPI.Features.Config;

namespace Application.Features.Queries
{
    public class GetUserIdByUserTokenHandler : DbConfiguration
    {
       
        public GetUserIdByUserTokenHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public byte[] GetUserIdByUserToken(String token)
        {
            byte[] user_id = new byte[16];
            try
            {

                MySqlConnection connection = new(this.ConnectionString);
                connection.Open();
                using var command = new MySqlCommand("SELECT user.id FROM user WHERE user.token = " + "@token", connection);
                command.Parameters.AddWithValue("@token", token);
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    user_id = rdr.GetFieldValue<byte[]>(0);
                }
                rdr.Close();
                return user_id;
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
