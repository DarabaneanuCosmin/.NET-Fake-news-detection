using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class IsEmailUsed : DbConfiguration
    {

        public IsEmailUsed(IConfiguration configuration) : base(configuration)
        {
        }

        public bool isUsed(string email_address)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionString);
                connection.OpenAsync();

                using var command = new MySqlCommand("SELECT * FROM user WHERE user.email_address = " 
                    + "@email_address", connection);
                command.Parameters.AddWithValue("@email_address", email_address);

                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0) && rdr.GetFieldValue<Byte[]>(0).Length > 0)
                    {
                        return true;
                    }

                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
            return false;
        }
    }
}
