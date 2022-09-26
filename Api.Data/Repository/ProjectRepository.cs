using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.DTOs.Request;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Repository;

public class ProjectRepository : IProject
{
    protected readonly AppDbContext _context;
    private DbSet<Project> _dataSet;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
        _dataSet = _context.Set<Project>();
    }

    public async Task<Project> RemoveAsync(int id)
    {
        var obj = await FindByIdAsync(id);

        _dataSet.Remove(obj);
        obj.Services.ForEach(x => _context.Services.Remove(x));
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<Project> FindByIdAsync(int id)
    {
        return _dataSet
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

        foreach (var service in projectReq.Services)
        {
            obj.Services.Add(new Service
            {
                Name = service.Name,
                Descritpion = service.Description,
                Cost = service.Cost,
                ProjectId = obj.Id
            });
        }

        await _dataSet.AddAsync(obj);
        obj.Services.ForEach(x => _context.Services.Add(x));
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<int> NextProjectId()
    {
        return _dataSet.Count() + 1;
    }

}