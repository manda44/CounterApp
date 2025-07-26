using CounterAppBack.Application.Interfaces;
using CounterAppBack.Domain;
using System.Data;

namespace CounterAppBack.Application.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventRepository.GetAllAsync();
        }

        public async Task AddAsync(Event newEvent)
        {
            await _eventRepository.AddAsync(newEvent);
        }

        public async Task UpdateAsync(Event newEvent)
        {
            await _eventRepository.UpdateAsync(newEvent);
        }

        public async Task DeleteAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Event>> GetByDateRangeAsync(DateTime ? startDate, DateTime ? endDate)
        {
            return await _eventRepository.GetByDateRangeAsync(startDate, endDate);
        }
    }
}
