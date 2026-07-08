namespace PSNTrophyTracker.Domain.Entities;
public class Entity
{
    public int Id {get;set;}
    public Guid ExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}