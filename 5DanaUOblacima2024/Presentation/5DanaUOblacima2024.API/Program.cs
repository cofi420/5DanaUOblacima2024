using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Implementation;
using _5DanaUOblacima2024.Application.Services.Interface;
using _5DanaUOblacima2024.Domain.Entities;
using _5DanaUOblacima2024.Persistence;
using _5DanaUOblacima2024.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("ESportsDatabase"));
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ITeamService, TeamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
