using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;
using minimalAPI.IRepositories;
using minimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped<IGenresRepo, GenresRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration.WithOrigins(builder.Configuration["allowedOrigins"]!).AllowAnyMethod();
    });
    options.AddPolicy("free", configuration =>
    {
        configuration.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseOutputCache();

app.MapGet("/genres", async (IGenresRepo repo) =>
{
    return await repo.GetAll();
}).CacheOutput(c=>c.Expire(TimeSpan.FromSeconds(50)));
app.MapGet("/genres/{id:int}", async (int id, IGenresRepo repo) =>
{
    var genre = await repo.GetById(id);
    if (genre is null) return Results.NotFound();
    return Results.Ok(genre);
});

app.MapPost("/genres", async (Genre obj, IGenresRepo repo) =>
{
    var id = await repo.Create(obj);
    return Results.Created($"/genres/{id}", obj);
});



app.Run();
