using DiscordExpeditionBot.Models.Expedition;
using DiscordExpeditionBot.Services;
using MongoDB.Driver;

namespace DiscordExpeditionBot.Repositories;

public class ExpeditionRepository(MongoDbService mongoDb) : IExpeditionRepository
{
    public Task<ExpeditionTemplate?> FetchExpeditionAsync(string expeditionId)
    {
        throw new NotImplementedException();
    }
}