using MongoDB.Bson.Serialization.Attributes;

namespace DiscordExpeditionBot.Models.Expedition;

public class Slot
{
    public int SlotIndex { get; set; }
    public required string RoleKey { get; set; }
    public ulong? UserId { get; set; }
    public string? CharacterName { get; set; }
    public string? CharacterClass { get; set; }
    public bool IsFlexible { get; set; } = false;    
    
    [BsonIgnore]
    public RoleDefinition? Role { get; set; }
}