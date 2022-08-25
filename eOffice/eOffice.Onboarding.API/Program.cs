using eOffice.Common.Redis;
using eOffice.Onboarding.DataAccess.Connections;
using eOffice.Onboarding.Services.Contracts;
using eOffice.Onboarding.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
// TODO: move into an extension
var databaseConnection = builder.Configuration["ConnectionStrings:Database"];
var pubSubConnection = builder.Configuration["ConnectionStrings:PubSubDatabase"];
var connection = new QueueMessagesConnection(databaseConnection, pubSubConnection);

builder.Services.AddTransient<QueueMessagesConnection>(x => connection);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(databaseConnection));

              
builder.Services.AddTransient<IOnboardingService, OnboardingService>();

// TODO: add into an extension the subscribe part


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
