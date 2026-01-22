using MongoDB.Bson.Serialization.Attributes;

namespace DiscordExpeditionBot.Models.Expedition;

public class Expedition
{
    [BsonId]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string TemplateId { get; set; } = "";
    public ulong HostId { get; set; }
    public ulong GuildId { get; set; }
    public ulong MessageId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ExpeditionState Status { get; set; } = ExpeditionState.Open;
    public ExpeditionLayout Layout { get; set; } = new();
}