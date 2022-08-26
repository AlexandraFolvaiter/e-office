using eOffice.Common.Redis;
using eOffice.Onboarding.DataAccess.Connections;
using eOffice.SystemAccounts.DataAccess.Repositories;
using eOffice.SystemAccounts_Services.Implementations;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient<ISystemAccountsRequestService, SystemAccountsRequestService>();
// DI repositories
builder.Services.AddTransient<ISystemAccountsRequestRepository, SystemAccountsRequestRepository>();

//
connection.GetSubscriber()
    .Subscribe(RedisChannelName.SystemAccountsChannel, (channel, message) =>
    {
        var serviceProvider = builder?.Services?.BuildServiceProvider();
        var service = serviceProvider?.GetService<ISystemAccountsRequestService>();

        service?.Add(message);
    });


//

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
