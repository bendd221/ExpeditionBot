using DiscordExpeditionBot.UiElements.Views;
using DiscordExpeditionBot.Services;
using NetCord;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;

namespace DiscordExpeditionBot.Modules;

public class UserUiCommands(ExpeditionManager expeditionManager)
    : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("initialize_user", "Registers you in the Expedition system if you haven't already.")]
    public async Task<InteractionMessageProperties> InitializeUserAsync()
    {
        var (isNew, user) = await expeditionManager.InitializeNewUserAsync(Context.User.Id);

        var embed = new EmbedProperties
        {
            Title = isNew ? "Welcome to the Expedition Bot!" : "Welcome back, Mapler!",
            Description = isNew
                ? $"✅ Your account has been created!\nDiscord ID: `{user.DiscordGuid}`"
                : $"ℹ️ You’re already registered!\nDiscord ID: `{user.DiscordGuid}`\nCharacters linked: `{user.Characters.Count}`"
        };

        return new InteractionMessageProperties
        {
            Embeds = [embed],
            Flags = MessageFlags.Ephemeral
        };
    }

    [SlashCommand("manage_user", "Registers you in the Expedition system if you haven't already.")]
    public async Task<InteractionMessageProperties> ManagerUserAsync()
    {
        var currentUser = await expeditionManager.GetUserAsync(Context.User.Id);
        return currentUser == null
            ? UserViews.UserNotFoundView()
            : UserViews.UserMenuView(currentUser);
    }
}