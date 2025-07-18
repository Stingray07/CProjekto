using Microsoft.AspNetCore.Mvc;
using MyApiProject.Services;
namespace MyApiProject.Controllers;

public class PlayerController : Controller
{
    private readonly IRiotApiService _riotApiService;

    public PlayerController(IRiotApiService riotApiService)
    {
        _riotApiService = riotApiService;
    }

    // // GET: /Player
    // public async Task<IActionResult> Index()
    // {
    //     return View();
    // }


    // GET: /Player/Details/5
    public async Task<IActionResult> Details(string encryptedPUUID)
    {
        //could just use a parameter for player searching if lazy
        //some data, should be database or api if not in db
        Player player = new Player {
            Id = 1,
            SummonerId = "1",
            SummonerName = "1heheh",
            Region = "1",
            Matches = new List<Match>(),
            ProfileIconId = 0,
            Level = 0,
            LastUpdated = DateTime.Now
        };
        Match match = new Match {
            MatchId = "1",
            GameCreation = DateTime.Now,
            ChampionId = 1,
            Win = true,
            Kills = 0,
            Deaths = 0,
            Assists = 0,
            PlayerId = 1,
            Player = player
        };

        player.Matches.Add(match);

        var summoner = await _riotApiService.GetSummonerByPUUIDAsync(encryptedPUUID);
        Console.WriteLine(summoner);

        if (encryptedPUUID == null) return NotFound();

        return View(player);
    }

}
