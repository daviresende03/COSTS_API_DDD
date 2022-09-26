namespace Api.Domain.DTOs.Request;

public class ProjectRequest
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal Cost { get; set; }
    public int CategoryId { get; set; }
    public List<ServiceRequest> Services { get; set; } = new List<ServiceRequest>();
}
