using MongoDB.Bson.Serialization.Attributes;

namespace DiscordExpeditionBot.Models.Expedition;

public class Party
{
    public required string PartyName { get; set; }
    public List<Slot> Slots { get; set; } = [];
    public int MaxPlayers { get; set; } = 6;
}