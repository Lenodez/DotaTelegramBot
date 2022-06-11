global using Microsoft.EntityFrameworkCore;
global using Telegram.Bot;
global using Telegram.Bot.Requests.Abstractions;
global using Telegram.Bot.Exceptions;
global using Telegram.Bot.Types;
global using Telegram.Bot.Types.Enums;
global using WebClient;
using WebClient.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>();
ReceiveServer receiveServer = new();
builder.Services.AddSingleton(receiveServer);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
