using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Models.Expedition;
using NetCord;
using NetCord.Rest;

namespace DiscordExpeditionBot.UiElements.Embeds;

public static class ExpeditionEmbeds
{
    public static EmbedProperties TemplateEditorEmbed(ExpeditionTemplate template)
    {
        var embed = new EmbedProperties
        {
            Title = string.IsNullOrWhiteSpace(template.Name) ? "New Expedition Template" : $"🛠️ Editing: {template.Name}",
            Color = new Color(0x5865F2),
            Footer = new EmbedFooterProperties { Text = "Template ID: " + template.Id }
        };
        
        if (template.Layout.Roles.Count > 0)
        {
            var roleList = string.Join("\n", template.Layout.Roles.Values.Select(r => 
                $"- **{r.RoleKey}**: {r.DisplayName} (_{string.Join(", ", r.AllowedClassIds ?? [])}_)"));
            
            embed.Description += $"### 📜 Role Definitions\n{roleList}\n\n";
        }
        else
        {
            embed.Description += "### 📜 Role Definitions\n_No roles defined yet._\n\n";
        }
        
        if (template.Layout.Parties.Count > 0)
        {
            for (var i = 0; i < template.Layout.Parties.Count; i++)
            {
                var party = template.Layout.Parties[i];
                var slotInfo = party.Slots.Count == 0 
                    ? "_No slots added_" 
                    : string.Join(" | ", party.Slots.Select(s => 
                        s.IsFlexible ? $"{s.RoleKey} (Flex)" : s.RoleKey));

                embed.AddFields(new EmbedFieldProperties
                {
                    Name = $"👥 {party.PartyName ?? $"Party {i + 1}"}",
                    Value = slotInfo,
                    Inline = false
                });
            }
        }
        else
        {
            embed.Description += "### 👥 Parties\n_No parties added yet._";
        }

        return embed;
    }
}