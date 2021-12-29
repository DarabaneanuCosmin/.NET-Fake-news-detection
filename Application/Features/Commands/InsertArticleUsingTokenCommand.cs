
namespace WebAPI.Features.Commands
{
    public class InsertArticleUsingTokenCommand
    {
        public string Token { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Subject { get; set; }

        public string Date_article { get; set; }

        public bool Is_fake { get; set; }
    }
}
