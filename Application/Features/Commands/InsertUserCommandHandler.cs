﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class InsertUserCommandHandler : DbConfiguration
    {
        public MySqlConnection connection;

        public InsertUserCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool insertUserDataAsync(InsertUserCommand insertUserCommand, string token)
        {
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                this.connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand("Insert into user (id,token, email_address, first_name, last_name, password)" +
                    " values(@id,@token, @email_address, @first_name, @last_name, @password)", this.connection);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@email_address", insertUserCommand.email_address);
                cmd.Parameters.AddWithValue("@first_name", insertUserCommand.first_name);
                cmd.Parameters.AddWithValue("@last_name", insertUserCommand.last_name);
                cmd.Parameters.AddWithValue("@password", Security.EncryptString(insertUserCommand.password));
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
