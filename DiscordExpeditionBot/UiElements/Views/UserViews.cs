using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.UiElements.Embeds;
using NetCord;
using NetCord.Rest;
using User = DiscordExpeditionBot.Models.User;

namespace DiscordExpeditionBot.UiElements.Views;
public static class UserViews
{
    public static InteractionMessageProperties UserNotFoundView()
        => new()
        {
            Embeds =
            [
                UserEmbeds.UserNotFound()
            ],
            Flags = MessageFlags.Ephemeral
        };

    public static InteractionMessageProperties UserMenuView(User currentUser)
    {
        var buttons = new ActionRowProperties()
        {
            new ButtonProperties("view_characters", "View Characters", ButtonStyle.Primary),
            new ButtonProperties("join_expedition", "Join Expedition", ButtonStyle.Success),
            new ButtonProperties("check_stats", "Check Stats", ButtonStyle.Secondary)
        };
        
        return new InteractionMessageProperties()
        {
            Embeds =
            [
                UserEmbeds.UserMenu(currentUser)
            ],
            Components = [buttons],
            Flags = MessageFlags.Ephemeral
        };        
    }

}