using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog{
    public static class Extend{
        public static ItemDto AsDto(this Ticket item){
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
    
}