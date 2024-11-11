using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;

namespace Solvace.TechCase.Repository.Contexts;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions options) : base(options) { }
    public DbSet<ActionPlan> ActionPlans { get; set; }
    public DbSet<ActionPlanStatus> ActionPlanStatus { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (EActionPlanStatus status in Enum.GetValues(typeof(EActionPlanStatus)))
        {
            modelBuilder.Entity<ActionPlanStatus>().HasData(new ActionPlanStatus
            {
                Id = (long)status,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                Name = status.ToString(),
                ExternalId = Guid.NewGuid().ToString()
            });
        }


    }
}
