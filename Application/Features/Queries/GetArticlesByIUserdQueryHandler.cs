using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebAPI.Features.Config;
using WebAPI.Responses;

namespace WebAPI.Features.Queries
{
    public class GetArticlesByUserIdQueryHandler : DbConfiguration
    {
    

        public GetArticlesByUserIdQueryHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public List<ArticleResponse> GetArticlesByUserId(GetArticlesByUserIdQuery query)
        {
            var articles = new List<ArticleResponse>();
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.Open();

                using var command = new MySqlCommand("SELECT * FROM article WHERE article.id_user = " + "@id_user", connection);
                command.Parameters.AddWithValue("@id_user", query.Id_user);
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    articles.Add(new ArticleResponse()
                    {
                        Id = rdr.GetFieldValue<int>(0),
                        Title = rdr.GetFieldValue<String>(2),
                        Text = rdr.GetFieldValue<String>(3),
                        Subject = rdr.GetFieldValue<String>(4),
                        Date_article = rdr.GetFieldValue<String>(5),
                        Is_fake = rdr.GetFieldValue<bool>(6)
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