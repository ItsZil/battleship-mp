using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestMessageController : ControllerBase
    {
        private readonly ILogger<TestMessageController> _logger;

        public TestMessageController(ILogger<TestMessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTestMessage")]
        public string Get()
        {
            return "Received this message from ServerApp successfully.";
        }
    }
}