namespace PSNTrophyTracker.Domain.Entities;

public class UserTrophy : Entity
{
    public int TrophyId { get; set; }
    public bool Earned { get; set; }
    public DateTime? EarnedAt { get; set; }
    public int? Progress { get; set; }
    public decimal ProgressRate { get; set; }

    public Trophy Trophy { get; set; }
}