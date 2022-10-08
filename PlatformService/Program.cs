using Microsoft.EntityFrameworkCore;
using PlatformService.AsyncDataServices;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<PlatformDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConnection")));
}
else 
{
    Console.WriteLine("--> Using InMem Db");

    builder.Services.AddDbContext<PlatformDbContext>(options => 
        options.UseInMemoryDatabase("PlatformDb"));
}


builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();

Console.WriteLine($"--> CommandsService Endpoint {builder.Configuration["CommandsService"]}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app,app.Environment.IsProduction());

app.Run();

