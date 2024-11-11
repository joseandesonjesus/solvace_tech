using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Services.Extensions;

namespace Solvace.TechCase.Services
{
    public class ActionPlanService
    {
        private readonly DefaultContext _context;

        public ActionPlanService()
        {
            var options = new DbContextOptionsBuilder<DefaultContext>()
            .UseSqlite("Data Source=database.db")
            .Options;

            _context = new DefaultContext(options);
        }

        public async Task<ActionPlanDto> Create(CreateActionPlan plan)
        {
            var newPlan = ActionPlan.Factories.Create(
                name: plan.Name,
                description: plan.Description,
                status: plan.StatusId
            );

            await _context.ActionPlans.AddAsync(newPlan);
            await _context.SaveChangesAsync();

            return newPlan.AsActionPlanDto();
        }
    }
}