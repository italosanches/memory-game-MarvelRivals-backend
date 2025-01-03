using MemoryGame.Context;
using MemoryGame.Entityes;
using MemoryGame.Repository;
using MemoryGame.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUserScoreService, UserScoreService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem (ajustar para uma origem específica em produção)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.MapGet("/getScores", async (IUserScoreService userScoreService) =>
{
    var scoreList = await userScoreService.GetScoreAsync();
    return Results.Ok(scoreList);
})
.WithName("GetScores")
.WithOpenApi();

app.MapPost("/addScore", async (IUserScoreService userScoreService,UserScore userScore) =>
{
    try
    {
        var newUserScore = await userScoreService.CreateUserScore(userScore);
        return Results.Created($"/getScores/{userScore.Id}", userScore);
    }
    catch (Exception ex) 
    {
        return Results.Problem($"Um erro ocorreu {ex.Message}", statusCode: 500);
    }
})
.WithName("AddScore")
.WithOpenApi();

app.Run();
