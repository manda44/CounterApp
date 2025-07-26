using CounterAppBack.Application.Services;
using CounterAppBack.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CounterAppBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetAll(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue) {
                return await _eventService.GetByDateRangeAsync(startDate,endDate);
            }
            else
            {
                return await _eventService.GetAllAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event newEvent)
        {
            await _eventService.AddAsync(newEvent);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Event newEvent)
        {
            if (id != newEvent.EventId)
            {
                return BadRequest();
            }

            await _eventService.UpdateAsync(newEvent);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);
            return Ok();
        }
    }
}