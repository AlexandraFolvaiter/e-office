using eOffice.Common.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

new QueueMessagesConnection("", $"redis-16341.c56.east-us.azure.cloud.redislabs.com:16341,password=qO53loElfTDgZHaeBXIdRSmAeKbbrpro")
    .GetSubscriber()
    .Subscribe(RedisChannelName.SystemAccountsChannel, (channel, message) => Console.WriteLine("Message received from test-channel : " + message));

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
