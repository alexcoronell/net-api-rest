using webapi.Models;
namespace webapi.Services;

public class TaskService: ITaskService
{
    TasksContext context;

    public TaskService(TasksContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Models.Task> Get()
    {
        return context.Tasks;
    }

    public async void Save(Models.Task task)
    {
        context.Add(task);
        await context.SaveChangesAsync();
    }

    public async void Update(Guid id, Models.Task task)
    {
        var currentTask = context.Tasks.Find(id);

        if(currentTask != null)
        {
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.CategoryId = task.CategoryId;
            currentTask.PriorityTask = task.PriorityTask;

            await context.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var currentTask = context.Categories.Find(id);

        if(currentTask != null)
        {
            context.Remove(currentTask);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITaskService
{
    IEnumerable<Models.Task> Get();
    void Save(Models.Task task);

    void Update(Guid id, Models.Task task);

    void Delete(Guid id);
}