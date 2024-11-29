using Solvace.TechCase.Domain.Entities.Product.Dtos;

namespace Solvace.TechCase.Domain.Interfaces
{
    public interface IProductServices
    {
        Task<ProductDto> Create(CreateProduct product);
        Task<ProductDto> GetProductByIdAsync(int id);
    }
}
