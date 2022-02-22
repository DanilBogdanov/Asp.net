using DanilDev.Data;
using DanilDev.Services.Prices.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.Prices
{
    public class PricesService
    {
        private ProjectsDbContext _priceContext;

        public PricesService(ProjectsDbContext priceContext)
        {
            _priceContext = priceContext;
        }

        public List<Price> GetPrices()
        {
            return _priceContext.Prices
                //.Include(pr => pr.Columns)
                .ToList();
        }

        public Price GetPrice(long id)
        {
            return _priceContext.Prices
                .Include(p => p.Columns)
                .Include(p => p.Lines)
                .SingleOrDefault(p => p.Id == id);
        }

        public void AddPrice(Price price)
        {
            _priceContext.Prices.Add(price);
            _priceContext.SaveChanges();
        }

        public void UpdatePrice(Price price)
        {
            if (price != null)
            {
                _priceContext.Prices.Update(price);
                _priceContext.SaveChanges();
            }
        }

        public void DeletePrice(long priceId)
        {
            if (priceId != 0)
            {
                var price = _priceContext.Prices.FirstOrDefault(p => p.Id == priceId);
                if (price != null)
                {
                    _priceContext.Prices.Remove(price);
                    _priceContext.SaveChanges();
                }
            }
        }

        public List<Line> GetLines(long priceId)
        {
            return _priceContext.PricesLines
                .Include(line => line.Items)
                .Where(line => line.PriceId == priceId).ToList();
        }

        public Line GetLine(long lineId)
        {
            return _priceContext.PricesLines
                .Include(line => line.Items)
                .SingleOrDefault(line => line.Id == lineId);
        }

        public void AddLine(Line line)
        {
            _priceContext.PricesLines.Add(line);
            _priceContext.SaveChanges();
        }

        public void UpdateLine(Line line)
        {
            if (_priceContext.PricesLines.Contains(line))
            {
                _priceContext.PricesLines.Update(line);
                _priceContext.SaveChanges();
            }
        }
                
        public void DelLine(long lineId)
        {
            if (lineId != 0)
            {
                var line = _priceContext.PricesLines.FirstOrDefault(p => p.Id == lineId);
                if (line != null)
                {
                    _priceContext.PricesLines.Remove(line);
                    _priceContext.SaveChanges();
                }
            }
        }
    }
}
