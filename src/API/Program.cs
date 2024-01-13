using Microsoft.OpenApi.Models;
using TA_JeanEdwards.API.Services;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTransient<ApiKeyHandler>();
builder.Services.AddHttpClient(ApiService.HTTP_CLIENT_KEY, cfg =>
{
    cfg.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!);
}).SetHandlerLifetime(TimeSpan.FromMinutes(15))
  .AddHttpMessageHandler<ApiKeyHandler>();

builder.Services.AddScoped<ApiService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "OMDb API Mediator",
            Version = "v1.1",
            Description = "Using http://www.omdbapi.com service API",
            Contact = new OpenApiContact() { Name = "Kyree Henry", Email = "ene.henry.eh@gmail.com" }
        });
});

WebApplication? app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
