using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Responses;
using WebAPIML.Model;

namespace WebAPI.Assemblers
{
    public static class ModelInputBuilder
    {
        public static ModelInput Builder(MLArticle article)
        {
            return new ModelInput()
            {
                Title = article.Title,
                Subject = article.Subject,
                Text = article.Text,
                Date = article.Date_article
            };
        }
    }
}
