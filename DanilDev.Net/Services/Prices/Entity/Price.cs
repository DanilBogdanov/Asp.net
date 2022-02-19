using System.Collections.Generic;

namespace DanilDev.Services.Prices.Entity
{
    public class Price
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public List<Line> Lines { get; set; } = new List<Line>();
    }
}
