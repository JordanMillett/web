using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<SettingService>();
builder.Services.AddScoped<ITextToSpeechService, TextToSpeechService>();
builder.Services.AddScoped<IAudioPlayerService, AudioPlayerService>();

await builder.Build().RunAsync();
