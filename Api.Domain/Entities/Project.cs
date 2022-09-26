namespace Api.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal Cost { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    // Lista não será mapeada, pois no BD o Project não tem relação com Service, mas sim ao contrário
    public virtual List<Service> Services { get; set; } = new List<Service>();
}
