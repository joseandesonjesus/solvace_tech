using Solvace.TechCase.Domain.Entities.Product.Dtos;
using Solvace.TechCase.Domain.Entities.Product;
using System.Numerics;

namespace Solvace.TechCase.Services.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDto AsProductDto(this Product product) => new ProductDto
        {
            Id = product.ExternalId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };
    }
}
