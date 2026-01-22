namespace DiscordExpeditionBot.Models;

public class Character
{
    public int CharacterId { get; set; }
    public string Name { get; set; }
    public string Class { get; set; } // Could also be enum
    public int Level { get; set; }
}