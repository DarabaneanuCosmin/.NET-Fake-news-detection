
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

        public async Task<List<Article>> GetArticlesByUserId(GetArticlesByUserIdQuery query)
        {
            var articles = new List<Article>();
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                await connection.OpenAsync();

                using var command = new MySqlCommand("SELECT * FROM article WHERE article.id_user = " + "@id_user", this.connection);
                command.Parameters.AddWithValue("@id_user", query.Id_user);
                MySqlDataReader rdr = command.ExecuteReader();
                while (await rdr.ReadAsync())
                {
                    articles.Add(new Article()
                    {
                        Id = await rdr.GetFieldValueAsync<int>(0),
                        //Id_user = await rdr.GetFieldValueAsync<Guid>(1),
                        Title = await rdr.GetFieldValueAsync<String>(2),
                        Text = await rdr.GetFieldValueAsync<String>(3),
                        Subject = await rdr.GetFieldValueAsync<String>(4),
                        Date_article = await rdr.GetFieldValueAsync<String>(5)
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