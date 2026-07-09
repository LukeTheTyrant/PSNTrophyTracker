namespace PSNTrophyTracker.Application.Games;

public class GameListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Platform { get; set; }
    public string? IconUrl { get; set; }
    public decimal Progress { get; set; }
    public int TotalTrophies { get; set; }
    public int EarnedTrophies { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}