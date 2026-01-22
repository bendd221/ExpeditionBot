using DiscordExpeditionBot.Models;

namespace DiscordExpeditionBot.Repositories;

public interface ICharacterRepository
{
    Task<List<Character>> FetchAllCharacters();
    Task InsertCharacter(Character character);
    Task UpdateCharacter(Character character);
    Task RemoveCharacter(Character character);
}