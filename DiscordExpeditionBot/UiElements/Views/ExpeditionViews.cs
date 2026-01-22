using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Models.Expedition;
using DiscordExpeditionBot.UiElements.Embeds;
using NetCord;
using NetCord.Rest;

namespace DiscordExpeditionBot.UiElements.Views;

public static class ExpeditionViews
{
    public static InteractionMessageProperties TemplateEditorView(ExpeditionTemplate template)
    {
        var row1 = new ActionRowProperties()
        {
            new ButtonProperties($"open_role_modal:{template.Id}", "Add Role", ButtonStyle.Primary),
            new ButtonProperties($"add_party:{template.Id}", "Add Party", ButtonStyle.Secondary)
        };
        
        var canAddSlot = template.Layout.Roles.Count > 0 && template.Layout.Parties.Count > 0;
        var row2 = new ActionRowProperties()
        {
            new ButtonProperties($"open_slot_selector:{template.Id}", "Add Slot", ButtonStyle.Success) 
                { Disabled = !canAddSlot },
            new ButtonProperties($"save_template:{template.Id}", "Save & Finish", ButtonStyle.Danger)
        };

        return new InteractionMessageProperties
        {
            Embeds = [ExpeditionEmbeds.TemplateEditorEmbed(template)],
            Components = [row1, row2],
            Flags = MessageFlags.Ephemeral
        };
    }
}