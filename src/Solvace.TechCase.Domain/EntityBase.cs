
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solvace.TechCase.Domain;

public abstract class EntityBase : IEntityBase
{
    [JsonIgnore]
    [Key]
    public long Id { get; set; }

    public required DateTimeOffset CreatedAt { get; set; }

    public required bool IsActive { get; set; }

    [JsonPropertyName("id")]
    public required string ExternalId { get; set; }
}
