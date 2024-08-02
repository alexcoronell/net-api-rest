using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldServices;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldServices = helloWorld;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("return Hello World");
        return Ok(helloWorldServices.GetHelloWorld());
    }
}