using DiscordExpeditionBot.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DiscordExpeditionBot.Models.Expedition;
using User = DiscordExpeditionBot.Models.User;

namespace DiscordExpeditionBot.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration config)
    {
        var client = new MongoClient(config["MONGODB_URI"]);
        _database = client.GetDatabase(config["MONGO_DB_NAME"]);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("users");
    public IMongoCollection<Character> Characters => _database.GetCollection<Character>("characters");
    public IMongoCollection<Expedition> Expeditions => _database.GetCollection<Expedition>("expeditionInstances");
    public IMongoCollection<ExpeditionTemplate> Drafts => _database.GetCollection<ExpeditionTemplate>("expeditionTemplateDrafts");
    public IMongoCollection<ExpeditionTemplate> ExpeditionTemplates => _database.GetCollection<ExpeditionTemplate>("expeditionTemplates");
}