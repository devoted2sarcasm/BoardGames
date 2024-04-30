using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using boardgames;
using boardgames.Services;
using boardgames.Models;

GameApiService gameApiService = new GameApiService();

//List<BoardGame>? BoardGames = await gameApiService.GetGames();


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<IGameApiService, GameApiService>();

await builder.Build().RunAsync();
