using DanilDev.Services.Prices.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.Prices
{
    public class PricesService
    {
        private PriceContext _priceContext;

        public PricesService(PriceContext priceContext)
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
            return _priceContext.Prices.SingleOrDefault(p => p.Id == id);
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
    }
}
