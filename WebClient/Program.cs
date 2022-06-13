global using Microsoft.EntityFrameworkCore;
global using Telegram.Bot;
global using Telegram.Bot.Exceptions;
global using Telegram.Bot.Types;
global using Telegram.Bot.Types.Enums;
global using WebClient.Commands;
global using WebClient.Modules;
global using WebClient;
using WebClient.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>();
builder.Services.AddSingleton<ICommandExecutor, CommandExecutor>();
builder.Services.AddSingleton<UpdateHandler>();
builder.Services.AddSingleton<TelegramBot>();
builder.Services.AddSingleton<BaseCommand, StartCommand>();


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

//Зависание при получении сервиса
var init = app.Services.GetRequiredService<TelegramBot>();
init.GetBot().Wait();

app.Run();
