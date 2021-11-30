using System;

namespace WebAPI.Entities
{
    public class Article
    {
        public int id { get; set; }

        public Guid Id_user { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Subject { get; set; }

        public DateTime Date { get; set; }
    }
}
