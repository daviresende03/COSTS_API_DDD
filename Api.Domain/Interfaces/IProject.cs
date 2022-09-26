using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
namespace Api.Domain.Interfaces;

public interface IProject
{
    Task<Project> FindByIdAsync(int id);
    Task<Project> InsertAsync(ProjectRequest projectReq);
    Task<Project> RemoveAsync(int id);
}
