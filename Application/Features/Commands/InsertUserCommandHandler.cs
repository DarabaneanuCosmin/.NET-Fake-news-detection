using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class InsertUserCommandHandler : DbConfiguration
    {

        public InsertUserCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool InsertUserDataAsync(InsertUserCommand insertUserCommand, string token)
        {
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.OpenAsync();
                MySqlCommand cmd = new("Insert into user (id,token, email_address, first_name, last_name, encoded_login_token)" +
                    " values(@id,@token, @email_address, @first_name, @last_name, @encoded_login_token)", connection);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@email_address", insertUserCommand.Email_address);
                cmd.Parameters.AddWithValue("@first_name", insertUserCommand.First_name);
                cmd.Parameters.AddWithValue("@last_name", insertUserCommand.Last_name);
                cmd.Parameters.AddWithValue("@encoded_login_token", Security.EncryptString(insertUserCommand.Password));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
