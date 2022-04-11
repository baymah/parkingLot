using System;
namespace Catalog.Entities{
    public record Ticket{
        public Guid Id { get; init; }
        public String Name { get; init; }
        public String ArrivalTime { get; init; }
        public String ExitTime { get; init; }
        public Decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}