using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repository{

    public class MongoDbPackingRulesRepository : IPackingRulesRepository
    {
        private const string databaseName = "db_a483f5_usertest";
        private const string collectionName = "PackingRules";
        private readonly IMongoCollection<PackingRules> packingRulesCollection;
        private FilterDefinitionBuilder<PackingRules> filterBuilder = Builders<PackingRules>.Filter;
        public MongoDbPackingRulesRepository(IMongoClient mongoClient){
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            packingRulesCollection = database.GetCollection<PackingRules>(collectionName);
        }

        public async Task CreatePackingRulesAsync(PackingRules packingRules)
        {
            await packingRulesCollection.InsertOneAsync(packingRules);
        }

        public async Task<PackingRules> GetPackingRuleByNameAsync(string packingRulesName)
        {
            var filter = filterBuilder.Eq(item => item.Name, packingRulesName);
            return await packingRulesCollection.Find(filter).SingleOrDefaultAsync();
        }
    }
}