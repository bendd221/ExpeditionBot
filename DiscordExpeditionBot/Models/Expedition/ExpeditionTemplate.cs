using DiscordExpeditionBot.Models.Expedition;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiscordExpeditionBot.Models.Expedition;

public class ExpeditionTemplate
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ExpeditionLayout Layout { get; set; } = new();
    
    [BsonRepresentation(BsonType.ObjectId)]
    public required string CreatorDiscordGuid { get; set; }    
}