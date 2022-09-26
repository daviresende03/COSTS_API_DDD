using Api.Domain.Interfaces;
using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
using Api.Data.Context;
namespace Api.Service.Services;

public class ProjectService : IProject
{
    private readonly AppDbContext _context;
    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Project> RemoveAsync(int id)
    {
        var obj = await FindByIdAsync(id);

        _context.Projects.Remove(obj);
        obj.Services.ForEach(x => _context.Services.Remove(x));
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<Project> FindByIdAsync(int id)
    {
        return _context.Projects
                .Include(x => x.Services)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
    }

    public async Task<Project> InsertAsync(ProjectRequest projectReq)
    {
        var obj = new Project
        {
            Id = NextProjectId().Result,
            Name = projectReq.Name,
            Budget = projectReq.Budget,
            Cost = projectReq.Cost,
            CategoryId = projectReq.CategoryId
            // Category = findById();
        };

        foreach(var service in projectReq.Services)
        {
            obj.Services.Add(new Service
            {
                Name = service.Name,
                Descritpion = service.Description,
                Cost = service.Cost,
                ProjectId = obj.Id
            });
        }

        await _context.Projects.AddAsync(obj);
        obj.Services.ForEach(x => _context.Services.Add(x));
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<int> NextProjectId()
    {
        return _context.Projects.Count() + 1;
    }
}
