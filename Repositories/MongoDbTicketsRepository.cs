using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repository{

    public class MongoDbTicketRepository : ITicketRepository
    {
        private const string databaseName = "db_a483f5_usertest";
        private const string collectionName = "PackingTickets";
        private readonly IMongoCollection<Ticket> ticketsCollection;
        private FilterDefinitionBuilder<Ticket> filterBuilder = Builders<Ticket>.Filter;
        public MongoDbTicketRepository(IMongoClient mongoClient){
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            ticketsCollection = database.GetCollection<Ticket>(collectionName);
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            await ticketsCollection.InsertOneAsync(ticket);
        }
        public async Task<IEnumerable<Ticket>> GetTicketsByDateAsync(DateTime date)
        {
            var datee = new DateTimeOffset(date);
            return await ticketsCollection.Find(x=>x.CreatedDate==datee).ToListAsync();
        }
        // public Task<IEnumerable<Ticket>> GetTicketsByDateAsync(DateTimeOffset date)
        // {
        //     throw new NotImplementedException();
        // }
    }
}