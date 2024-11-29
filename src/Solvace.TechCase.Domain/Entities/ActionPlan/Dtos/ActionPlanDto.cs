namespace Solvace.TechCase.Domain.Entities.ActionPlan.Dtos
{
    public class ActionPlanDto
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public long Status { get; set; }
        public DateTimeOffset? EndedAt { get; set; }
        public required string TypeName { get; set; }
    }
}