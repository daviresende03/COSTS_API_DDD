namespace Api.Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descritpion { get; set; }
    public decimal Cost { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
