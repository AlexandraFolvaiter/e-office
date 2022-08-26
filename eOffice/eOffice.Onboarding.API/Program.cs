using eOffice.Common.Models;
using eOffice.Common.Redis;
using eOffice.Onboarding.DataAccess.Connections;
using eOffice.Onboarding.DataAccess.Repositories;
using eOffice.Onboarding.DataAccess.Repositories.Contracts;
using eOffice.Onboarding.Services.Contracts;
using eOffice.Onboarding.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI databases
// TODO: move into an extension
var databaseConnection = builder.Configuration["ConnectionStrings:Database"];
var pubSubConnection = builder.Configuration["ConnectionStrings:PubSubDatabase"];

var connection = new QueueMessagesConnection(pubSubConnection);

builder.Services.AddTransient<QueueMessagesConnection>(x => connection);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(databaseConnection));

// DI services              
builder.Services.AddTransient<IOnboardingService, OnboardingService>();
builder.Services.AddTransient<IOnboardingPubSubService, OnboardingPubSubService>();

// DI repositories
builder.Services.AddTransient<IOnboardingRepository, OnboardingRepository>();


// TODO: add into an extension the subscribe part
connection
    .GetSubscriber()
    .Subscribe(RedisChannelName.OnboardingChannel, (channel, message) =>
    {
        var serviceProvider = builder?.Services?.BuildServiceProvider();
        var service = serviceProvider?.GetService<IOnboardingPubSubService>();

        var messageAsObject = JsonConvert.DeserializeObject<OnboardUpdateMessage>(message);

        service?.Update(messageAsObject);
    });

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
