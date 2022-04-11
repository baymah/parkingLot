using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repository;
using Catalog.Entities;
using System.Linq;
using Catalog.Dtos;
using System.Threading.Tasks;
using Catalog.Helpers;

namespace Catalog.Controllers{

//Get /items
    [ApiController]
    [Route("packingrules")]
    public class PackingRulesController : ControllerBase{
        private readonly IPackingRulesRepository _repository;

        public PackingRulesController(IPackingRulesRepository repository){
            _repository = repository;
        }
        
        [HttpPost]
        public async Task<ActionResult> CreatePackingRulesAsync(CreatePackingRulesDto createPackingRulesDto)
        {
             PackingRules packingRules = new()
            {
                 Id= Guid.NewGuid(),
                 Name = createPackingRulesDto.Name,
                 CreatedDate=DateTimeOffset.UtcNow,
                 EntranceFee = createPackingRulesDto.EntranceFee,
                 FirstFullOrParialHourCost = createPackingRulesDto.FirstFullOrParialHourCost,
                 SuccessiveFullOrpartial=createPackingRulesDto.SuccessiveFullOrpartial,
                 TimeFormat= createPackingRulesDto.TimeFormat,
                 EntryTime= createPackingRulesDto.EntryTime,
                 ExitTime=createPackingRulesDto.ExitTime                 
            };
                await  _repository.CreatePackingRulesAsync(packingRules);
            // return CreatedAtAction(nameof(GetItemsAsync), new { id = item.Id }, item.AsDto());
            return Ok();
        }  
    }
}