using DanilDev.Services.Prices.Entity;
using DanilDev.Services.Prices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DanilDev.Pages.Prices
{
    public class IndexModel : PageModel
    {
        private readonly PricesService _priceService;
        [BindProperty(SupportsGet = true)]
        public long PriceId { get; set; }
        public List<Price> Prices { get; set; }
        public Price Price { get; set; }
        public IndexModel(PricesService priceService)
        {
            _priceService = priceService;
        }

        public void OnGet()
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            Prices = _priceService.GetPrices();
            if (PriceId != 0)
            {
                Price = _priceService.GetPrice(PriceId);
            }
        }
    }
}
