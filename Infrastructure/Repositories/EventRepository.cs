using CounterAppBack.Application.Interfaces;
using CounterAppBack.Domain;
using CounterAppBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CounterAppBack.Infrastructure.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Event entity)
        {
            await _context.Set<Event>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Set<Event>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<Event>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _context.Events.Where(e => e.EventDate >= startDate && e.EventDate <= endDate).ToListAsync();
        }
    }
}
