using Microsoft.Extensions.Options;
using MongoCrudTest.Models;
using MongoDB.Driver;

namespace MongoCrudTest.Services
{
    public class SecondService
    {
        private readonly IMongoCollection<SecondModel> _collection;
        public SecondService(IOptions<DatabaseSettings> testDatabaseSettings)
        {
            var mongoClient = new MongoClient(testDatabaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(testDatabaseSettings.Value.DatabaseName);
            _collection = mongoDb.GetCollection<SecondModel>(testDatabaseSettings.Value.SecondCollectionName);
        }


        public async Task<List<SecondModel>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<SecondModel?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(SecondModel newTestModel) =>
            await _collection.InsertOneAsync(newTestModel);

        public async Task UpdateAsync(string id, SecondModel updatedSecondModel) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedSecondModel);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
