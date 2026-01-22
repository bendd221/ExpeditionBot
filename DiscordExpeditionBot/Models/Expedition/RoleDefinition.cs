namespace DiscordExpeditionBot.Models.Expedition;

public class RoleDefinition
{
    public required string RoleKey { get; set; }
    public string? DisplayName { get; set; }
    public bool IsFlexible { get; set; } 
    public List<string> AllowedClassIds { get; set; } = [];
}