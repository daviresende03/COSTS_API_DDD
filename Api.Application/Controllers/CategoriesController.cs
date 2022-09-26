using Api.Domain.DTOs.Request;
using Api.Domain.Interfaces;
using Api.Service.Services;
namespace Api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategory _categoryService;
    public CategoriesController(ICategory categServ)
    {
        _categoryService = categServ;
    }


    [HttpGet("{id:int}", Name = "GetCategories")]
    public async Task<IResult> Get([FromRoute] int id)
    {
        var result = await _categoryService.FindByIdAsync(id);
        if(result == null)
            return Results.NotFound("Id inexistente no banco de dados.");
        return Results.Ok(new CategoryResponse { Id = result.Id, Name = result.Name });
    }

    [HttpGet(Name = "GetAllCategories")]
    public async Task<IResult> Get()
    {
        var result = await _categoryService.FindAllAsync();
        if (result == null)
            return Results.NotFound("Não existe Categorias cadastradas.");
        return Results.Ok(result);
    }

    [HttpPost(Name = "PostCategories")]
    public async Task<IResult> Post([FromBody] CategoryRequest categoryRequest)
    {
        var result = await _categoryService.FindByNameAsync(categoryRequest.Name);
        if (result != null)
            return Results.BadRequest(new {Message = "Categoria já cadastrada.", Category = result});

        var category = await _categoryService.InsertAsync(categoryRequest);
        return Results.Created($"/categories/{category.Id}", category.Id);
    }

    [HttpDelete("{id:int}", Name = "DeleteCategories")]
    public async Task<IResult> Delete([FromRoute] int id)
    {
        var obj = await _categoryService.RemoveAsync(id);
        if (!obj)
        {
            return Results.BadRequest("Houve um erro ao deletar a categoria.");
        }
        return Results.Ok();
    }
}
