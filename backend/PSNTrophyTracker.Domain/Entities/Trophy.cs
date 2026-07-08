using PSNTrophyTracker.Domain.Enums;

namespace PSNTrophyTracker.Domain.Entities;

public class Trophy : Entity
{
    public int GameId { get; set; }
    public int PsnTrophyId { get; set; }
    public int GroupId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public TrophyType Type { get; set; }
    public TrophyRare Rare { get; set; }
    public decimal TrophyEarnedRate { get; set; }
    public bool IsHidden { get; set; }
    public string? IconUrl { get; set; }

    public Game Game { get; set; }
}