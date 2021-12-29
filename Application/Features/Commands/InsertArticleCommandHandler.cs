using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using WebAPI.Features.Config;

namespace WebAPI.Features.Commands
{
    public class InsertArticleCommandHandler : DbConfiguration
    {

        public InsertArticleCommandHandler(IConfiguration configuration) : base(configuration)
        {
        }

        public bool InsertArticle(InsertArticleCommand article)
        {
            try
            {
                MySqlConnection connection = new(this.ConnectionString);
                connection.OpenAsync();
                MySqlCommand cmd = new("Insert into article (id_user, title, text, subject, date_article, is_fake)" +
                    " values(@id_user, @title, @text, @subject, @date_article, @is_fake)", connection);
                cmd.Parameters.AddWithValue("@id_user", article.Id_user);
                cmd.Parameters.AddWithValue("@title", article.Title);
                cmd.Parameters.AddWithValue("@text", article.Text);
                cmd.Parameters.AddWithValue("@subject", article.Subject);
                cmd.Parameters.AddWithValue("@date_article", article.Date_article);
                cmd.Parameters.AddWithValue("@is_fake", article.Is_fake);
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
