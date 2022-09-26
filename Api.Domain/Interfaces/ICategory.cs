using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
namespace Api.Domain.Interfaces;

public interface ICategory
{
    Task<IEnumerable<Category>> FindAllAsync();
    Task<Category> FindByIdAsync(int id);
    Task<Category> FindByNameAsync(string name);
    Task<Category> InsertAsync(CategoryRequest categoryReq);
    Task<bool> RemoveAsync(int id);
    Task<bool> ExistProjectWithThisCategoryAsync(Category category);
}
