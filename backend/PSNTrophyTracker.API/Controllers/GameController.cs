
using Microsoft.AspNetCore.Mvc;
using PSNTrophyTracker.Application.Games;

namespace PSNTrophyTracker.API.Controllers;

[ApiController]
[Route("api/game")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService; 

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameListItemDto>>> Get()
    {
        var games = await _gameService.GetGamesAsync();

        return Ok(games);
    }
}