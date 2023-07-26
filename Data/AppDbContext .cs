using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiNet7.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Book> Books { get; set; }
    }
}
