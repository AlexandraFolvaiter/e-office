using eOffice.Onboarding.DataAccess.Connections;
using eOffice.Onboarding.Services.Contracts;
using eOffice.Onboarding.Services.Implementation;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IOnboardingService, OnboardingService>();

new QueueMessagesConnection().GetSubscriber().Subscribe("account_insert", (channel, message) => Console.Write("Message received from test-channel : " + message));

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
