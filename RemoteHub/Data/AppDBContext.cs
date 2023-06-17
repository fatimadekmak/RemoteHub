using Microsoft.EntityFrameworkCore;
using RemoteHub.Models;

namespace RemoteHub.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Resume> Resumes { get; set; }
    }
}
