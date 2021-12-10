using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers.v1
{
    [ApiController]

    public class MachineLearningController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public bool IsArticleFake([FromBody] MLArticle article)
        {
            return true;
        }
    }
}
