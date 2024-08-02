using webapi.Models;
namespace webapi.Services;

public class CategoryService : ICategoryService
{
    TasksContext context;

    public CategoryService(TasksContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public async void Save(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }

    public async void Update(Guid id, Category category)
    {
        var currentCategory = context.Categories.Find(id);

        if(currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            currentCategory.Weight = category.Weight;

            await context.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var currentCategory = context.Categories.Find(id);

        if(currentCategory != null)
        {
            context.Remove(currentCategory);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    void Save(Category category);

    void Update(Guid id, Category category);

    void Delete(Guid id);
}