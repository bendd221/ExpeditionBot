using DiscordExpeditionBot.Models.Expedition;

namespace DiscordExpeditionBot.Repositories;

public interface IExpeditionRepository
{
    Task<ExpeditionTemplate?> FetchExpeditionAsync(string expeditionId);
}