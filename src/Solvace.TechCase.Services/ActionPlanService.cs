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

            try
            {
                if (!Enum.IsDefined(typeof(EActionPlanStatus), plan.StatusId))
                    throw new ArgumentException("StatusId inválido.");

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
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
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
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task<ActionPlanDto> UpdateActionPlanAsync(int id, UpdateActionPlanDto updateDto)
        {
            try
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
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task<ActionPlanDto> DeactivateActionPlanAsync(int id)
        {
            try
            {
                var actionPlan = await _context.ActionPlans
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(ap => ap.Id == id && ap.IsActive);

                if (actionPlan == null)
                    throw new KeyNotFoundException("Action Plan not found.");

                actionPlan.IsActive = false;
                _context.ActionPlans.Update(actionPlan);
                await _context.SaveChangesAsync();

                return actionPlan.AsActionPlanDto();
            }
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task<ActionPlanDto> GetActionPlanByIdAsync(int id)
        {
            try
            {
                var actionPlan = await _context.ActionPlans
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(ap => ap.Id == id);

                if (actionPlan == null)
                    throw new KeyNotFoundException("Action Plan not found.");

                return actionPlan.AsActionPlanDto();
            }
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task<PaginationDto<ActionPlanDto>> GetAllActionPlansAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (actionPlans, totalCount) = await _context.ActionPlans.AsNoTracking()
                                                                    .PaginateAsync(pageNumber, pageSize);

                return actionPlans.Select(x => x.AsActionPlanDto())
                                  .AsPaginationDto(totalCount, pageNumber, pageSize);
            }
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }
    }
}