using Microsoft.EntityFrameworkCore;
using Shortener.Models;

namespace Shortener.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}
