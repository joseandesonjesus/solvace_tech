using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;
using Solvace.TechCase.Domain.Interfaces;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Services.Extensions;

namespace Solvace.TechCase.Services
{
    public class ActionPlanService : IActionPlanService
    {
        private readonly DefaultContext _context;

        public ActionPlanService(DefaultContext context)
        {
            _context = context;
        }

        public async Task<ActionPlanDto> CreateAsync(CreateActionPlan plan)
        {
        
                if (!Enum.IsDefined(typeof(EActionPlanStatus), plan.StatusId))
                {
                    throw new ArgumentException("StatusId inválido.");
                }

                var newPlan = ActionPlan.Factories.Create(
                    name: plan.Name,
                    description: plan.Description,
                    status: plan.StatusId,
                    typeName: plan.TypeName
                );

                await _context.ActionPlans.AddAsync(newPlan);
                await _context.SaveChangesAsync();

                return newPlan.AsActionPlanDto();
        }

        public async Task<ActionPlanDto> EndActionPlanAsync(int id)
        {
            try
            {
                var actionPlan = await _context.ActionPlans.FindAsync(long.Parse(id.ToString()));

                if (actionPlan == null)
                    throw new KeyNotFoundException("Action Plan not found.");

                actionPlan.ActionPlanStatusId = (int)EActionPlanStatus.COMPLETED;
                actionPlan.EndedAt = DateTime.UtcNow;
                _context.ActionPlans.Update(actionPlan);
                await _context.SaveChangesAsync();

                return actionPlan.AsActionPlanDto();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ActionPlanDto> UpdateActionPlanAsync(int id, UpdateActionPlanDto updateDto)
        {
            var actionPlan = await _context.ActionPlans
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(ap => ap.Id == id
                                                                    && ap.IsActive
                                                                    && !ap.ActionPlanStatusId.Equals((int)EActionPlanStatus.COMPLETED));

            if (actionPlan == null)
                throw new KeyNotFoundException("Action Plan not found.");

            actionPlan.Name = updateDto.Name;
            actionPlan.Description = updateDto.Description;

            _context.ActionPlans.Update(actionPlan);
            await _context.SaveChangesAsync();

            return actionPlan.AsActionPlanDto();
        }

        public async Task<ActionPlanDto> DeactivateActionPlanAsync(int id)
        {
            var actionPlan = await _context.ActionPlans
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(ap => ap.Id == id && ap.IsActive);

            if (actionPlan == null)
            {
                throw new KeyNotFoundException("Action Plan não encontrado.");
            }

            actionPlan.IsActive = false;
            _context.ActionPlans.Update(actionPlan);
            await _context.SaveChangesAsync();

            return actionPlan.AsActionPlanDto();
        }

        public async Task<ActionPlanDto> GetActionPlanByIdAsync(int id)
        {
            var actionPlan = await _context.ActionPlans
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(ap => ap.Id == id);

            if (actionPlan == null)
                throw new KeyNotFoundException("Action Plan not found.");

            return actionPlan.AsActionPlanDto();
        }

        public async Task<PaginationDto> GetAllActionPlansAsync(int pageNumber, int pageSize)
        {
            var source = _context.ActionPlans.AsNoTracking();
            var (items, totalCount) = await source.PaginateAsync(pageNumber, pageSize);

            var actionPlans = items.Select(plan => new ActionPlanDto
            {
                Id = plan.Id.ToString(),
                Name = plan.Name,
                Description = plan.Description,
                Status = plan.ActionPlanStatusId,
                TypeName = plan.TypeName,
                EndedAt = plan.EndedAt
            }).ToList();

            return new PaginationDto(actionPlans, totalCount, pageNumber, pageSize);
        }
    }
}