
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;

namespace Solvace.TechCase.Domain.Entities.ActionPlan;

/// <summary>
/// Represents a ActionPlan entity.
/// </summary>
public class ActionPlan : EntityBase
{

    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(4000)]
    public required string Description { get; set; }

    [JsonIgnore]
    public required long ActionPlanStatusId { get; set; }
    public ActionPlanStatus ActionPlanStatus { get; set; }
    public DateTimeOffset? EndedAt { get; set; }
    
    [MinLength(3)]
    [MaxLength(30)]
    public required string TypeName { get; set; }

    public static class Factories
        {
            public static ActionPlan Create(string name, string description, EActionPlanStatus status, string typeName)
            {
                return new ActionPlan
                {
                    Name = name,
                    Description = description,
                    ActionPlanStatusId = (long)status,
                    ExternalId = Guid.NewGuid().ToString(),
                    TypeName = typeName,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };
            }
        }
}
