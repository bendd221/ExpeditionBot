using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DiscordExpeditionBot.Models;

public class User
{
    [BsonId] // Marks this as the MongoDB _id field
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public required ulong DiscordGuid { get; set; }

    public bool IsAdmin { get; set; }

    // Make sure to have public getter and setter for Mongo serialization
    public List<Character> Characters { get; set; } = [];

    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }
}