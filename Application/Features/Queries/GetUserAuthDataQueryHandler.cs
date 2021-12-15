using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Config;
using WebAPI.Responses;

namespace WebAPI.Features.Queries
{
    public class GetUserAuthDataQueryHandler : DbConfiguration
    {

        public GetUserAuthDataQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public UpdateUserResponse isUser(GetUserAuthDataQuery user)
        {
            UpdateUserResponse updateUserResponse = new UpdateUserResponse();
            try
            {
                MySqlConnection connection = new MySqlConnection(this.connectionString);
                connection.OpenAsync();

                using var command = new MySqlCommand("SELECT * FROM user WHERE user.email_address = " +
                    "@email_address" + " AND user.encoded_login_token = " +
                    "@EncryptedPassword", connection);
                command.Parameters.AddWithValue("@email_address", user.email_address);
                command.Parameters.AddWithValue("@EncryptedPassword", Security.EncryptString(user.encryptedPassword));

                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0) && rdr.GetFieldValue<Byte[]>(0).Length > 0)
                    {
                        updateUserResponse.id = rdr.GetFieldValue<Byte[]>(0);
                        updateUserResponse.result = true;
                        return updateUserResponse;
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
            updateUserResponse.result = false;

            return updateUserResponse;

        }
    }

}
