namespace PSNTrophyTracker.Application.Games;

public interface IGameService
{
    Task<List<GameListItemDto>> GetGamesAsync();
}