using PSNTrophyTracker.Domain.Enums;

namespace PSNTrophyTracker.Domain.Entities;

public class Game : Entity
{
    public string NpCommunicationId { get; set; }
    public string NpServiceName { get; set; }
    public string Title { get; set; }
    public Platform Platform { get; set; }
    public string? IconUrl { get; set; }
    public decimal Progress { get; set; }
    public int BronzeCount { get; set; }
    public int SilverCount { get; set; }
    public int GoldCount { get; set; }
    public int PlatinumCount { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    public ICollection<Trophy> Trophies { get; set; } = new List<Trophy>();
}