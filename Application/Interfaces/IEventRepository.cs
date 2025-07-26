using CounterAppBack.Domain;

namespace CounterAppBack.Application.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task AddAsync(Event entity);
        Task UpdateAsync(Event entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Event>> GetByDateRangeAsync(DateTime? startDate, DateTime ? endDate);
    }
}
