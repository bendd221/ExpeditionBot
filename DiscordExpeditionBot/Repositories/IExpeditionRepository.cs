using DiscordExpeditionBot.Models.Expedition;

namespace DiscordExpeditionBot.Repositories;

public interface IExpeditionRepository
{
    Task<Expedition?> FetchExpeditionAsync(string expeditionId);
    Task<List<Expedition>> FetchAllExpeditionTemplatesByUserId();
}