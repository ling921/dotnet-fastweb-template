using FastWeb.Storage;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddFile(configuration.GetSection("Logging"));

// Add services to the container.
builder.Services.AddSqlite<AppDbContext>(configuration.GetConnectionString("Default"));
builder.Services.AddFeatures();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseFeatures();

app.Run();
