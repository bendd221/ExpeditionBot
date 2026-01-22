using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Services;
using MongoDB.Driver;
using System.Text.Json;

namespace DiscordExpeditionBot.Repositories;

public class UserRepository(MongoDbService mongoDb, RedisService redis) : IUserRepository
{
    public async Task<User?> GetUserByDiscordGuid(ulong discordGuid)
    {
        var key = $"user:{discordGuid}";
        var cachedUser = await redis.Database.StringGetAsync(key);

        if (cachedUser.HasValue)
        {
            Console.WriteLine("Found user in redis");
            return JsonSerializer.Deserialize<User>(cachedUser.ToString());
        }
        
        var filter = Builders<User>.Filter.Eq(u => u.DiscordGuid, discordGuid);
        var mongoUser = await mongoDb.Users.Find(filter).FirstOrDefaultAsync();

        if (mongoUser is null) return mongoUser;
        await CacheUserAsync(mongoUser);

        return mongoUser;
    }

    public async Task CreateUser(User user)
    {
        await mongoDb.Users.InsertOneAsync(user);
        await CacheUserAsync(user);   
    }

    public Task DeleteUser(User user)
        => throw new NotImplementedException();

    public Task UpdateUser(User user)
        => throw new NotImplementedException();

    public Task<List<Character>> FetchAllCharactersOfUser(User user)
        => throw new NotImplementedException();
    
    private async Task CacheUserAsync(User user)
    {
        var key = $"user:{user.DiscordGuid}";
        var json = JsonSerializer.Serialize(user);
        await redis.Database.StringSetAsync(key, json, TimeSpan.FromHours(2));
    }   
}