using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldServices;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldServices = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldServices.GetHelloWorld());
    }
}