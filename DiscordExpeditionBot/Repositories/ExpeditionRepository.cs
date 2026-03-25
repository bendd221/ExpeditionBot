using DiscordExpeditionBot.Models.Expedition;
using DiscordExpeditionBot.Services;
using MongoDB.Driver;

namespace DiscordExpeditionBot.Repositories;

public class ExpeditionRepository(MongoDbService mongoDb) : IExpeditionRepository
{
    public Task<Expedition?> FetchExpeditionAsync(string expeditionId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<List<ExpeditionTemplate>?> FetchAllExpeditionTemplatesByUserId(string userId)
    {
        var expeditionTemplates = await mongoDb.ExpeditionTemplates.FindAsync(expeditionTemplate => expeditionTemplate.UserId == userId);
        return expeditionTemplates.ToList();
    }
}