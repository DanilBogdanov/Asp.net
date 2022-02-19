using DanilDev.Services.Prices.Entity;
using Microsoft.EntityFrameworkCore;

namespace DanilDev.Services.Prices
{
    public class PriceContext : DbContext
    {
        public DbSet<Price> Prices { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Item> Items { get; set; }

        public PriceContext(DbContextOptions<PriceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
