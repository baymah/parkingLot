using System;
namespace Catalog.Entities{
    public record CreatePackingRulesDto{
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string EntranceFee { get; init; }
        public string FirstFullOrParialHourCost { get; init; }
        public string SuccessiveFullOrpartial { get; init; }
        public String TimeFormat { get; init; }
        public String EntryTime { get; init; }
        public String ExitTime { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}