using DiscordExpeditionBot.Models;

namespace DiscordExpeditionBot.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByDiscordGuid(ulong discordGuid);
    Task CreateUser(User user);
    Task DeleteUser(User user);
    Task UpdateUser(User user);
    Task<List<Character>> FetchAllCharactersOfUser(User user);
}