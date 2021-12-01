
﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Features.Config;

namespace WebAPI.Features.Queries
{
    public class GetArticlesByUserIdQueryHandler : DbConfiguration
    {
        public MySqlConnection connection;

        public GetArticlesByUserIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Article> GetArticlesByUserId(GetArticlesByUserIdQuery query)
        {
            var articles = new List<Article>();
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                connection.Open();

                using var command = new MySqlCommand("SELECT * FROM article WHERE article.id_user = " + "@id_user", this.connection);
                command.Parameters.AddWithValue("@id_user", query.Id_user);
                MySqlDataReader rdr = command.ExecuteReader();
                while ( rdr.Read())
                {
                    articles.Add(new Article()
                    {
                        Id = rdr.GetFieldValue<int>(0),
                        //Id_user = await rdr.GetFieldValueAsync<Guid>(1),
                        Title =  rdr.GetFieldValue<String>(2),
                        Text =  rdr.GetFieldValue<String>(3),
                        Subject =  rdr.GetFieldValue<String>(4),
                        Date_article =  rdr.GetFieldValue<String>(5)
                    });

                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }

            return articles;
        }
    }
}