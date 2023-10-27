using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        public DbSet<TShirt> TShirts { get; set; }
    }
}