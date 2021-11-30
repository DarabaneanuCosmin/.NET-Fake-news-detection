using System;

namespace WebAPI.Features.Commands
{
    public class InsertArticleCommand
    {
        
        public Guid id_user { get; set; }

        public string title { get; set; }

        public string text { get; set; }

        public string subject { get; set; }

        public string date_time { get; set; }
    }
}
