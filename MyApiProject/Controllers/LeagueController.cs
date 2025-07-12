using Microsoft.AspNetCore.Mvc;

public class LeagueController : Controller
{
        // GET: /League
    public IActionResult Index()
    {
        return View();
    }
}