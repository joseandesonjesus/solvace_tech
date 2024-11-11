namespace Solvace.TechCase.Domain;

public interface IEntityBase
{
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ExternalId { get; set; }
    public bool IsActive { get; set; }
}
