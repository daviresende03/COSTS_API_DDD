using Api.Domain.Interfaces;
using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
using Api.Data.Repository;
namespace Api.Service.Services;

public class CategoryService : ICategory
{
    private CategoryRepository _repository;
    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> FindAllAsync()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<Category> FindByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task<Category> FindByNameAsync(string name)
    {
        return await _repository.FindByNameAsync(name);
    }

    public async Task<Category> InsertAsync(CategoryRequest categoryReq)
    {
        return await _repository.InsertAsync(categoryReq);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        return await _repository.RemoveAsync(id);
    }
}
