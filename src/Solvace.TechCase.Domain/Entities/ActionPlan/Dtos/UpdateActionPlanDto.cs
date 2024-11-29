using System.ComponentModel.DataAnnotations;

namespace Solvace.TechCase.Domain.Entities.ActionPlan.Dtos
{
    public class UpdateActionPlanDto
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(4000)]
        public required string Description { get; set; }
    }
}
