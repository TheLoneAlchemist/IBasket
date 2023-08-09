using IBasket.Models;
using Microsoft.EntityFrameworkCore;

namespace IBasket.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MissingItem> MissingItems { get; set; }
    }
}
