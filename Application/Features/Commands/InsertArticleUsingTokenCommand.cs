using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands
{
    public class InsertArticleUsingTokenCommand
    {
        public string token { get; set; }

        public string title { get; set; }

        public string text { get; set; }

        public string subject { get; set; }

        public string date_article { get; set; }

        public bool is_fake { get; set; }
    }
}
