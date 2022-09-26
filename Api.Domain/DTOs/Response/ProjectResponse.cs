namespace Api.Domain.DTOs.Response;

public class ProjectResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal Cost { get; set; }
    public CategoryResponse Category { get; set; }
    public List<ServiceResponse> Services { get; set; } = new List<ServiceResponse>();
}
