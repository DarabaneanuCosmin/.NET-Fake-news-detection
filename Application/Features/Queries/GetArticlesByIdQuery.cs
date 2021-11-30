using System;

namespace WebAPI.Features.Queries
{
   public class GetArticlesByIdQuery
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Subject { get; set; }

        public DateTime Date { get; set; }

    }
}
