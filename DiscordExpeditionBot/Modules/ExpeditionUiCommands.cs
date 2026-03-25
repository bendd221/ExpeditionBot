using DiscordExpeditionBot.Models.Expedition;
using DiscordExpeditionBot.UiElements.Views;
using NetCord;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.Commands;
using NetCord.Services.ComponentInteractions;
namespace DiscordExpeditionBot.Modules;

public class ExpeditionUiCommands : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("create_new_expedition", "New Expedition Creation.")]
    public async Task<InteractionMessageProperties> InitializeNewExpeditionAsync()
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

}

