using System.ComponentModel.DataAnnotations;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;

namespace Solvace.TechCase.Domain.Entities.ActionPlan.Dtos
{
    public class CreateActionPlan
    {

        /// <summary>
        /// The title or name of the action plan, limited to 50 characters.
        /// </summary>
        [MaxLength(50)]
        [MinLength(3)]
        public required string Name { get; set; }        

        /// <summary>
        /// A detailed description of the action plan, with a maximum length of 4000 characters.
        /// </summary>
        [MaxLength(4000)]
        [MinLength(3)]
        public required string Description { get; set; }

        public EActionPlanStatus StatusId { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        public required string TypeName { get; set; }

    }
}