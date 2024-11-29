using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.Product.Dtos;
using Solvace.TechCase.Domain.Entities.Product;
using Solvace.TechCase.Domain.Interfaces;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Services.Extensions;

namespace Solvace.TechCase.Services
{
    public class ProductService : IProductServices
    {
        private readonly DefaultContext _context;

        public ProductService(DefaultContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Create(CreateProduct createProduct)
        {
            try
            {
                var product = Product.Factories.Create(
                    name: createProduct.Name,
                    description: createProduct.Description,
                    price: createProduct.Price
                );

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return product.AsProductDto();
            }
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(ap => ap.Id == id);

                if (product == null)
                    throw new KeyNotFoundException("Product not found");

                return product.AsProductDto();
            }
            catch
            {
                throw new ApplicationException("Application failed to search for product by id, try later or contact the administrator");
            }
        }
    }
}
