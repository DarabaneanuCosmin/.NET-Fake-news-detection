using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{   
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController: ControllerBase
    {
    }
}