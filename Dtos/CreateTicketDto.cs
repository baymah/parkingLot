using System.ComponentModel.DataAnnotations;

namespace Catalog.Entities{
    public class CreateTicketTimeDto{
        [Required]
        public string EntryTime { get; set; }
        [Required]
        public string ExitTime { get; set; }
        public string TicketRuleName { get; set; }
    }
}