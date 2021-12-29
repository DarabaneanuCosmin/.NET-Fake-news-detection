using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using WebAPI.Features.Config;
using WebAPI.Responses;

namespace WebAPI.Features.Queries
{
    public class GetUserAuthDataQueryHandler : DbConfiguration
    {

        public GetUserAuthDataQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public UpdateUserResponse IsUser(GetUserAuthDataQuery user)
        {
            UpdateUserResponse updateUserResponse = new();
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.OpenAsync();

                using var command = new MySqlCommand("SELECT * FROM user WHERE user.email_address = " +
                    "@email_address" + " AND user.encoded_login_token = " +
                    "@EncryptedPassword", connection);
                command.Parameters.AddWithValue("@email_address", user.Email_address);
                command.Parameters.AddWithValue("@EncryptedPassword", Security.EncryptString(user.EncryptedPassword));

                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0) && rdr.GetFieldValue<Byte[]>(0).Length > 0)
                    {
                        updateUserResponse.Id = rdr.GetFieldValue<Byte[]>(0);
                        updateUserResponse.Result = true;
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
            updateUserResponse.Result = false;

            return updateUserResponse;

        }
    }

}
