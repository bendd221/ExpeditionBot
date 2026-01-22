using DiscordExpeditionBot.Models;
using DiscordExpeditionBot.Services;
using MongoDB.Driver;

namespace DiscordExpeditionBot.Repositories;

public class MongoCharacterRepository(MongoDbService mongoDb) : ICharacterRepository
{
    public async Task<List<Character>> FetchAllCharacters()
    {
        var characters = await mongoDb.Characters.Find(_ => true).ToListAsync();
        return characters;
    }

    public async Task InsertCharacter(Character character)
    {
        await mongoDb.Characters.InsertOneAsync(character);
    }

    public async Task UpdateCharacter(Character character)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.CharacterId, character.CharacterId);
        await mongoDb.Characters.ReplaceOneAsync(filter, character);
    }

    public async Task RemoveCharacter(Character character)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.CharacterId, character.CharacterId);
        await mongoDb.Characters.DeleteOneAsync(filter);
    }
}