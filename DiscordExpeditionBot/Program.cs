using DiscordExpeditionBot.Repositories;
using DiscordExpeditionBot.Services;
using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCord;
using NetCord.Hosting.Services.ComponentInteractions;
using NetCord.Services.ComponentInteractions;
using MongoDB.Bson.Serialization.Conventions;

var conventionPack = new ConventionPack
{
    new CamelCaseElementNameConvention()
};
ConventionRegistry.Register(
    "CamelCaseConvention",
    conventionPack,
    t => true // apply to all classes
);

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services
    .AddSingleton<MongoDbService>()
    .AddSingleton<RedisService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<ICharacterRepository, MongoCharacterRepository>()
    .AddScoped<IExpeditionRepository, ExpeditionRepository>()
    .AddScoped<ExpeditionManager>()
    .AddComponentInteractions<ButtonInteraction, ButtonInteractionContext>()
    .AddComponentInteractions<ModalInteraction, ModalInteractionContext>()
    .AddDiscordGateway()
    .AddApplicationCommands();

var host = builder.Build();

host.AddModules(typeof(Program).Assembly);
host.UseGatewayEventHandlers();
await host.RunAsync();


