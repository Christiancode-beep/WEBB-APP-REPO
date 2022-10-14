using Microsoft.EntityFrameworkCore;
using WEB_APP3.Models;

namespace WEB_APP3.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
              
        }
        public DbSet<Category> Categories { get; set; }
    }
}
