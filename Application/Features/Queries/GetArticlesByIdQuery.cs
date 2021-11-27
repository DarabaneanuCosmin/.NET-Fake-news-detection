using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    class GetArticlesByIdQuery
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Subject { get; set; }

        public DateTime Date { get; set; }
        
    }
}
