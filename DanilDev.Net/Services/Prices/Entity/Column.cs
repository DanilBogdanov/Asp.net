namespace DanilDev.Services.Prices.Entity
{
    public class Column
    {
        public long Id { get; set; }     
        public string Name { get; set; }
        public Price Price { get; set; }
        public long PriceId { get; set; }
        public TypeColumn Type { get; set; }
    }
}
