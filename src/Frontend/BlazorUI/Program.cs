using Blazored.LocalStorage;
using TA_JeanEdwards.BlazorUI.Pages;
using TA_JeanEdwards.BlazorUI.Services;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<SearchHistoryService>();
builder.Services.AddHttpClient(ApiService.HTTP_CLIENT_KEY, cfg =>
{
    cfg.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!);
}).SetHandlerLifetime(TimeSpan.FromMinutes(15));
builder.Services.AddScoped<ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
