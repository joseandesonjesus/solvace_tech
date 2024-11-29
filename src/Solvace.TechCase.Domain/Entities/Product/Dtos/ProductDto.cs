namespace Solvace.TechCase.Domain.Entities.Product.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
    }
}
