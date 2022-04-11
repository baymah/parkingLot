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
    [Route("ticker")]
    public class TicketController : ControllerBase{
        private readonly ITicketRepository _repository;
        private readonly IPackingRulesRepository _packingRuleRepo;

        public TicketController(ITicketRepository repository, IPackingRulesRepository packingRuleRepo){
            _repository = repository;
            _packingRuleRepo = packingRuleRepo;
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateTicketAsync(CreateTicketTimeDto ticketTimeDto)
        {
            var rules = await _packingRuleRepo.GetPackingRuleByNameAsync(ticketTimeDto.TicketRuleName);
            // var sol = new Solution(2,3,4);
            var sol = new Solution(Int32.Parse(rules.EntranceFee),Int32.Parse(rules.FirstFullOrParialHourCost),Int32.Parse(rules.SuccessiveFullOrpartial));
            var result =sol.solution(ticketTimeDto.EntryTime, ticketTimeDto.ExitTime);
             Ticket ticket = new()
            {
                 Id= Guid.NewGuid(),
                 Name ="Default",
                 ArrivalTime= ticketTimeDto.EntryTime,
                 ExitTime= ticketTimeDto.ExitTime,
                 Price=result,
                 CreatedDate=DateTimeOffset.UtcNow
                 
            };
                await  _repository.CreateTicketAsync(ticket);
            return Ok();
        }
        [HttpGet("{date}")]
        public async Task<ActionResult<Ticket>> GetTicketByDateAsync(DateTime date)
        {
            var ticker = await _repository.GetTicketsByDateAsync(date);
            return Ok(ticker);
        }            
    }
}