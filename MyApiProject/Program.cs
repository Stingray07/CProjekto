var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("RiotApi");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();

var riotApiKey = builder.Configuration["RiotApi:ApiKey"];
builder.Services.AddHttpClient("RiotApi", client => {
    client.BaseAddress = new Uri("https://ph2.api.riotgames.com");
    client.DefaultRequestHeaders.Add("X-Riot-Token", riotApiKey);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
