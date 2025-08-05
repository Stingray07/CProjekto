using MyApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRiotApiService, RiotApiService>();
builder.Services.AddControllersWithViews();
var riotApiKey = builder.Configuration["RiotApi:ApiKey"];
builder.Services.AddHttpClient("RiotApi", client => {
    client.BaseAddress = new Uri("https://sg2.api.riotgames.com");
    client.DefaultRequestHeaders.Add("X-Riot-Token", riotApiKey);
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine($"API Key: {riotApiKey}"); // Check if this shows your key

app.Run();

// for development
// dotnet user-secrets set "RiotApi:ApiKey" "YOUR_API_KEY"
