using System.Collections.Generic;

namespace DanilDev.Services.Prices.Entity
{
    public class Line
    {
        public long Id { get; set; }
        public Price Price { get; set; }
        public long PriceId { get; set; }
        public List<Item> Items { get; set; }
    }
}
