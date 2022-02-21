namespace DanilDev.Services.Prices.Entity
{
    public class Item
    {
        public long Id { get; set; }
        //public Line Line { get; set; }
        public long LineId { get; set; }
        //public Price Price { get; set; }
        public long PriceId { get; set; }
        //public Column Column { get; set; }
        public long ColumnId { get; set; }
        public double ? NumericValue { get; set; }
        public string StrValue{ get; set; }        
    }
}
