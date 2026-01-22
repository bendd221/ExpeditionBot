using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Services;
using NetCord;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using User = DiscordExpeditionBot.Models.User;

namespace DiscordExpeditionBot.UiElements.Embeds;

public static class UserEmbeds
{
    public static EmbedProperties UserNotFound()
        => new EmbedProperties()
        {
            Title = "User not found!",
            Description = "Please initialize your user with initialize_user to start using this bot!"
        };
    
    public static EmbedProperties UserMenu(User currentUser)
    {
        var greeting = $"Hello <@{currentUser.DiscordGuid}>! Welcome to your Expedition menu.";
        var options = 
            "- View Characters\n" +
            "- Join Expedition\n" +
            "- Check Stats";

        // var buttons = new ActionRowProperties()
        // {
        //     new ButtonProperties("view_characters", "View Characters", ButtonStyle.Primary),
        //     new ButtonProperties("join_expedition", "Join Expedition", ButtonStyle.Success),
        //     new ButtonProperties("check_stats", "Check Stats", ButtonStyle.Secondary)
        // };
        
        return new EmbedProperties
        {
            Title = "Your User Menu",
            Description = $"{greeting}\n\n**Available actions:**\n{options}",
            Footer = new EmbedFooterProperties
            {
                Text = "Select an action using the buttons below."
            }
        };
    }
}