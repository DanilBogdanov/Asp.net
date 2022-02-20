using DanilDev.Services.Prices.Entity;
using Microsoft.EntityFrameworkCore;

namespace DanilDev.Services.Prices
{
    public class PriceContext : DbContext
    {
        public DbSet<Price> Prices { get; set; }
        public DbSet<Column> PricesColumns { get; set; }
        public DbSet<Line> PricesLines { get; set; }
        public DbSet<Item> PricesItems { get; set; }

        public PriceContext(DbContextOptions<PriceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
