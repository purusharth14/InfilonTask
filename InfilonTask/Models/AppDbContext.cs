using Microsoft.EntityFrameworkCore;

namespace InfilonTask.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }

    }
}
