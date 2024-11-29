using System.ComponentModel.DataAnnotations;

namespace Solvace.TechCase.Domain.Entities.Product.Dtos
{
    public class CreateProduct
    {
        [MaxLength(255)]
        [MinLength(3)]
        public required string Name { get; set; }
        [MaxLength(4000)]
        [MinLength(3)]
        public required string Description { get; set; }
        public required double Price { get; set; }
    }
}
