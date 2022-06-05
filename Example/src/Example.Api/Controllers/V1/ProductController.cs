using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    }
}
