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
        public List<Price> Prices { get; set; }
        
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
            
        }
    }
}
