using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class InsertArticleCommandHandler: DbConfiguration
    {
        public MySqlConnection connection;

        public InsertArticleCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool InsertArticle(InsertArticleCommand article)
        {
            try
            {
                this.connection = new MySqlConnection(this.connectionString);
                this.connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand("Insert into article (id_user, title, text, subject, date_article)" +
                    " values(@id_user, @title, @text, @subject, @date_article)", this.connection);
                cmd.Parameters.AddWithValue("@id_user", article.id_user);
                cmd.Parameters.AddWithValue("@title", article.title);
                cmd.Parameters.AddWithValue("@text", article.text);
                cmd.Parameters.AddWithValue("@subject", article.subject);
                cmd.Parameters.AddWithValue("@date_article", article.date_article);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
