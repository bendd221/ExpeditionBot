namespace DiscordExpeditionBot.Models.Expedition;

public class ExpeditionLayout
{
    public Dictionary<string, RoleDefinition> Roles { get; set; } = [];
    public List<Party> Parties { get; set; } = [];
    
    public void LinkRoles()
    {
        foreach (var slot in Parties.SelectMany(party => party.Slots))
        {
            if (Roles.TryGetValue(slot.RoleKey, out var foundRole))
            {
                slot.Role = foundRole;
            }
        }
    }
}