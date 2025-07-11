using Microsoft.AspNetCore.Mvc;

public class WeatherForecastController : Controller
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // GET: /WeatherForecast
    public IActionResult Index()
    {
        var forecasts = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            
        return View(forecasts);
    }

    // GET: /WeatherForecast/Details/5
    public IActionResult Details(int id)
    {
    // In a real app, you'd get this from a database
    var forecast = new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    };

    return View(forecast);
}

    // GET: /WeatherForecast/Create
    public IActionResult Create()
    {
        return View();
    }

}