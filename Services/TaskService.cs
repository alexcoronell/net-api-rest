using Microsoft.EntityFrameworkCore.Metadata.Internal;
using webapi.Models;

namespace webapi.Services;

public class TaskService
{
    TasksContext dbContext;

    public TaskService(TasksContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public IEnumerable<TaskService> Get()
    {
        return (IEnumerable<TaskService>)dbContext.Tasks;
    }

    public async void Save(Models.Task task)
    {
        dbContext.Add(task);
        await dbContext.SaveChangesAsync();

    }

    public async void Update(Guid id, Models.Task task)
    {
        var currentTask = dbContext.Tasks.Find(id);
        if (currentTask != null)
        {
            currentTask.CategoryId = task.CategoryId;
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.PriorityTask = task.PriorityTask;
            await dbContext.SaveChangesAsync();

        }
    }

    public async void Delete(Guid id)
    {
        var currentTask = dbContext.Tasks.Find(id);
        if (currentTask != null)
        {
            dbContext.Remove(currentTask);
            await dbContext.SaveChangesAsync();

        }
    }
}

public interface ITaskService
{
    IEnumerable<TaskService> Get();
    void Save(Models.Task task);
    void Update(Guid id, Models.Task task);
    void Delete(Guid id);
}