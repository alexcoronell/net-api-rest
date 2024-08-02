using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    ITaskService taskService;

    public TaskController(ITaskService _service)
    {
        taskService = _service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(taskService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Models.Task task)
    {
        taskService.Save(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Models.Task task)
    {
        taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        taskService.Delete(id);
        return Ok();
    }
}