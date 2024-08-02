using webapi.Models;

namespace webapi.Services;

public class CategoryService
{
    TasksContext dbContext;

    public CategoryService(TasksContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public IEnumerable<CategoryService> Get()
    {
        return (IEnumerable<CategoryService>)dbContext.Categories;
    }

    public async void Save(Category category)
    {
        dbContext.Add(category);
        await dbContext.SaveChangesAsync();

    }

    public async void Update(Guid id, Category category)
    {
        var currentCategory = dbContext.Categories.Find(id);
        if (currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            currentCategory.Weight = category.Weight;
            await dbContext.SaveChangesAsync();
        }
    }

    public async void Delete(Guid id)
    {
        var currentCategory = dbContext.Categories.Find(id);
        if (currentCategory != null)
        {
            dbContext.Remove(currentCategory);
            await dbContext.SaveChangesAsync();

        }
    }
}

public interface ICategoryService
{
    IEnumerable<CategoryService> Get();
    void Save(Category category);
    void Update(Guid id, Category category);
    void Delete(Guid id);
}