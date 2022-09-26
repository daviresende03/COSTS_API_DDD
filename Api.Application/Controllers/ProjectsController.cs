using Api.Domain.DTOs.Request;
using Api.Domain.Interfaces;
using Api.Service.Services;
namespace Api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProject _projectService;
    public ProjectsController(IProject projServ)
    {
        _projectService = projServ;
    }
    
    [HttpGet("{id:int}",Name = "GetProjects")]
    public async Task<IResult> Get([FromRoute] int id)
    {
        try
        {
            var result = await _projectService.FindByIdAsync(id);
            if (result == null)
                return Results.NotFound("Id inexistente no banco de dados.");

            var proj = new ProjectResponse
            {
                Id = result.Id,
                Name = result.Name,
                Budget = result.Budget,
                Cost = result.Cost,
                Category = new CategoryResponse
                {
                    Id = result.Category.Id,
                    Name = result.Category.Name
                }
            };
            foreach (var serv in result.Services)
            {
                proj.Services.Add(new ServiceResponse
                {
                    Id = serv.Id,
                    Name = serv.Name,
                    Description = serv.Descritpion,
                    Cost = serv.Cost
                });
            }
            return Results.Ok(proj);
        }
        catch(Exception ex)
        {
            return Results.BadRequest(new { Mensagem = "Houve um erro ao recuperar o Projeto", Erro = $"{ex.Message}" });
        }
    }

    [HttpPost(Name = "PostProjects")]
    public async Task<IResult> Post([FromBody] ProjectRequest projReq)
    {
        try
        {
            var result = await _projectService.InsertAsync(projReq);
            return Results.Created($"/projects/{result.Id}", result.Id);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { Mensagem = "Houve um erro ao recuperar o Projeto", Erro = $"{ex.Message}" });
        }
    }

    [HttpDelete("{id:int}",Name = "DeleteProjects")]
    public async Task<IResult> Delete([FromRoute] int id)
    {
        try
        {
            await _projectService.RemoveAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { Mensagem = "Houve um erro ao recuperar o Projeto", Erro = $"{ex.Message}" });
        }
    }
}