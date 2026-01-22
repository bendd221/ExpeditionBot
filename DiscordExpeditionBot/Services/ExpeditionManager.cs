using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Repositories;

namespace DiscordExpeditionBot.Services;

public class ExpeditionManager(IUserRepository userRepo, ICharacterRepository charRepo, IExpeditionRepository expRepo)
{
    public async Task<(bool IsNew, User User)> InitializeNewUserAsync(ulong discordGuid, bool isAdmin = false)
    {
        var existingUser = await GetUserAsync(discordGuid);
        if (existingUser is not null)
            return (false, existingUser);

        var newUser = new User
        {
            DiscordGuid = discordGuid,
            IsAdmin = isAdmin,
            Characters = []
        };

        await userRepo.CreateUser(newUser);
        Console.WriteLine($"User with Discord GUID {discordGuid} inserted.");

        return (true, newUser);
    }

    public async Task<User?> GetUserAsync(ulong discordGuid)
    {
        return await userRepo.GetUserByDiscordGuid(discordGuid);
    }
}