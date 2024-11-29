using Solvace.TechCase.Domain.Entities;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;

namespace Solvace.TechCase.Domain.Interfaces
{
    public interface IActionPlanService
    {
        Task<ActionPlanDto> CreateAsync(CreateActionPlan actionPlan);
        Task<ActionPlanDto> EndActionPlanAsync(int id);
        Task<ActionPlanDto> UpdateActionPlanAsync(int id, UpdateActionPlanDto updateDto);
        Task<ActionPlanDto> DeactivateActionPlanAsync(int id);
        Task<ActionPlanDto> GetActionPlanByIdAsync(int id);
        Task<PaginationDto> GetAllActionPlansAsync(int pageNumber, int pageSize);
    }
}
