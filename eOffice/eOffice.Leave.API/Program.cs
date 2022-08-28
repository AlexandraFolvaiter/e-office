using eOffice.Common.Redis;
using eOffice.Leave.DataAccess.Connections;
using eOffice.Leave.DataAccess.Repositories;
using eOffice.Leave.Models;
using eOffice.Leave.Services.Contracts;
using eOffice.Leave.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI databases
var databaseConnection = builder.Configuration["ConnectionStrings:Database"];
var pubSubConnection = builder.Configuration["ConnectionStrings:PubSubDatabase"];

var connection = new QueueMessagesConnection(pubSubConnection);

builder.Services.AddTransient<QueueMessagesConnection>(x => connection);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(databaseConnection));

connection.GetSubscriber()
    .Subscribe(RedisChannelName.LeaveChannel, (channel, message) =>
    {
        var serviceProvider = builder?.Services?.BuildServiceProvider();
        var service = serviceProvider?.GetService<ILeaveService>();

        var messageAsObject = JsonConvert.DeserializeObject<LeaveBalanceModel>(message);

        service?.Add(messageAsObject);
    });

// DI services
builder.Services.AddTransient<ILeaveService, LeaveService>();

// DI repositories
builder.Services.AddTransient<ILeaveRepository, LeaveRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
