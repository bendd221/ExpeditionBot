using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using NRedisStack;
using NRedisStack.RedisStackCommands;

namespace DiscordExpeditionBot.Services;

public class RedisService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _db;

    public RedisService(IConfiguration config)
    {
        var options = new ConfigurationOptions
        {
            EndPoints = { config["REDIS_HOST"] ?? "localhost:6379" },
            Password = config["REDIS_PASSWORD"],
            User = config["REDIS_USER"],
            AbortOnConnectFail = false,
            AllowAdmin = true
        };

        _redis = ConnectionMultiplexer.Connect(options);
        _redis.GetServer(_redis.GetEndPoints()[0]).FlushAllDatabases();

        _db = _redis.GetDatabase();
    }

    public IJsonCommands Json => _db.JSON();
    public IDatabase Database => _db;
}