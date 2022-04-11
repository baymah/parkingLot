using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repository{
    public interface ITicketRepository
    {
        // Task<Ticket> GetTicketAsync(Guid id);
        // Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsByDateAsync(DateTime date);
        Task CreateTicketAsync(Ticket item);
    }
}