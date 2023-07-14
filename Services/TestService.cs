using Microsoft.Extensions.Options;
using MongoCrudTest.Models;
using MongoDB.Driver;

namespace MongoCrudTest.Services
{
    public class TestService
    {
        private readonly IMongoCollection<TestModel> _collection;
        public TestService(IOptions<DatabaseSettings> testDatabaseSettings) 
        {
            var mongoClient = new MongoClient(testDatabaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(testDatabaseSettings.Value.DatabaseName);
             _collection = mongoDb.GetCollection<TestModel>(testDatabaseSettings.Value.TestCollectionName);
        }


        public async Task<List<TestModel>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<TestModel?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TestModel newTestModel) =>
            await _collection.InsertOneAsync(newTestModel);

        public async Task UpdateAsync(string id, TestModel updatedTestModel) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedTestModel);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
