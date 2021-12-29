using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;
using WebAPIML.Model;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class MachineLearningController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public bool IsArticleFake([FromBody] MLArticle article)
        {
            var input = new ModelInput()
            {
                Title = article.Title,
                Subject = article.Subject,
                Text = article.Text,
                Date = article.Date_article
            };

            ModelOutput result = ConsumeModel.Predict(input);

            return result.Prediction == "fake ";
        }
    }
}
