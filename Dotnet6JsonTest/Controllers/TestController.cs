using Microsoft.AspNetCore.Mvc;

namespace Dotnet6JsonTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        
        public TestController()
        {
            
        }

        [HttpPost()]
        public IActionResult Get(TestInput input)
        {
            var result = new
            {
                Input = input,
                Message = "Success"
            };

            return Ok(result);
        }
    }
}