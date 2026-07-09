using Microsoft.EntityFrameworkCore;
using PSNTrophyTracker.Application.Games;
using PSNTrophyTracker.Infrastructure.Persistence;

namespace PSNTrophyTracker.Infrastructure.Games;

public class GameService : IGameService
{
    private readonly AppDbContext _context;

    public GameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GameListItemDto>> GetGamesAsync()
    {
        return await _context.Games
                    .AsNoTracking()
                    .Select(game => new GameListItemDto
                    {
                        Id = game.Id,
                        Title = game.Title,
                        Platform = game.Platform.ToString(),
                        IconUrl = game.IconUrl,
                        Progress = game.Progress,
                        TotalTrophies = game.Trophies.Count,
                        EarnedTrophies = game.Trophies
                                            .Count(trophy => _context.UserTrophies
                                                    .Any(userTrophy => userTrophy.TrophyId == trophy.Id 
                                                        && userTrophy.Earned)),
                        LastUpdatedAt = game.LastUpdatedAt
                    })
                    .ToListAsync();
    }
}