using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Assemblers;
using WebAPI.Responses;
using WebAPIML.Model;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    public class MachineLearningController : BaseController
    {
        const string FAKE = "fake ";

        [EnableCors]
        [HttpPost]
        public bool IsArticleFake([FromBody] MLArticle article, [FromServices] ModelInputBuilder model)
        {
            var input = model.builder(article);

            ModelOutput result = ConsumeModel.Predict(input);

            return result.Prediction == FAKE;
        }
    }
}
