using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using SharedLibrary.Models;

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
        public IActionResult Get()
        {
            var testMessage = new TestMessage("Received this message from ServerApp successfully.");
            return Ok(testMessage);
        }
    }
}