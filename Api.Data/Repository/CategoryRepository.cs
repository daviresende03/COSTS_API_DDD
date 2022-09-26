using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Repository;

public class CategoryRepository : ICategory
{
    protected readonly AppDbContext _context;
    private DbSet<Category> _dataSet;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
        _dataSet = _context.Set<Category>();
    }

    public async Task<IEnumerable<Category>> FindAllAsync()
    {
        return _context.Categories.ToList();
    }

    public async Task<Category> FindByIdAsync(int id)
    {
        return _context.Categories.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Category> FindByNameAsync(string name)
    {
        return _context.Categories.FirstOrDefault(x => x.Name == name);
    }

    public async Task<Category> InsertAsync(CategoryRequest categoryReq)
    {
        await _context.Categories.AddAsync(new Category { Name = categoryReq.Name });
        await _context.SaveChangesAsync();

        var obj = await FindByNameAsync(categoryReq.Name);
        return obj;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        try
        {
            var category = await FindByIdAsync(id);
            // Verifica se existe algum projeto no Banco de dados utilizando essa categoria
            if (category == null)
                return false;
            if (await ExistProjectWithThisCategoryAsync(category))
                return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> ExistProjectWithThisCategoryAsync(Category category)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Category == category);
        if (project == null)
            return false;
        return true;
    }
}