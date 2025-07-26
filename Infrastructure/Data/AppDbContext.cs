using CounterAppBack.Domain;
using Microsoft.EntityFrameworkCore;

namespace CounterAppBack.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        
    }
}
