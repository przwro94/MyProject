namespace MyProject.WebAPI.Dtos;

public class OrderCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}