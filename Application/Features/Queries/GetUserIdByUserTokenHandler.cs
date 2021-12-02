using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WebAPI.Entities;
using WebAPI.Features.Config;

namespace Application.Features.Queries
{
    public class GetUserIdByUserTokenHandler : DbConfiguration
    {
        private MySqlConnection connection;

        public GetUserIdByUserTokenHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public byte[] GetUserIdByUserToken(String token)
        {
            byte[] user_id = new byte[16];
            try
            {
                
                this.connection = new MySqlConnection(this.connectionString);
                connection.Open();
                using var command = new MySqlCommand("SELECT user.id FROM user WHERE user.token = " + "@token", this.connection);
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
