using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{   
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors]
    public class BaseController: ControllerBase
    {
    }
}