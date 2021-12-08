using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers.v1
{
    [ApiController]

    public class MachineLearningController : BaseController
    {
        [EnableCors]
        [HttpPost]
        public bool IsArticleFake([FromBody] Article article)
        {
            return true;
        }
    }
}
