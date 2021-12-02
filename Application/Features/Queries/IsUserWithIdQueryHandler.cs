using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WebAPI.Entities;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class IsUserWithIdQueryHandler : DbConfiguration
    {
        private MySqlConnection connection;

        public IsUserWithIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool IsUserWithId(Guid query)
        {
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                connection.Open();

                using var command = new MySqlCommand("SELECT * FROM user WHERE user.id = " + "@id", this.connection);
                command.Parameters.AddWithValue("@id", query);
                MySqlDataReader rdr = command.ExecuteReader();
                /*while ( rdr.Read())
                {
                    if (rdr.GetFieldValue<byte[]>(0).Length > 0 )
                        return true;
                    return false;
                }*/
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
