using MyProject.WebAPI.Dtos;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Extensions;

public static class OrderMappingExtensions
{
    public static Order ToOrder(this OrderCreateDto orderCreateDto)
    {
        return new Order
        {
            Name = orderCreateDto.Name,
            Description = orderCreateDto.Description,
            Price = orderCreateDto.Price
        };
    }
}