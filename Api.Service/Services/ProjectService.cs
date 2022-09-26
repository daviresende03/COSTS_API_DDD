using Api.Domain.Interfaces;
using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
using Api.Data.Repository;
namespace Api.Service.Services;

public class ProjectService : IProject
{
    private ProjectRepository _repository;
    public ProjectService(ProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Project> RemoveAsync(int id)
    {
        return await _repository.RemoveAsync(id);
    }

    public async Task<Project> FindByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task<Project> InsertAsync(ProjectRequest projectReq)
    {
        return await _repository.InsertAsync(projectReq);
    }
}
