using PSNTrophyTracker.Domain.Enums;

namespace PSNTrophyTracker.Domain.Entities;
public class SyncHistory : Entity
{    
    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public SyncStatus Status { get; set; }
    public int GamesProcessed { get; set; }
    public int TrophiesProcessed { get; set; }
    public string? ErrorMessage { get; set; }    
}