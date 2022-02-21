using DanilDev.Services.Prices;
using DanilDev.Services.Prices.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.Prices
{
    public class AddLineModel : PageModel
    {
        public Price Price { get; set; }
        private readonly PricesService _pricesService;
        [BindProperty(SupportsGet = true)]
        public int PriceId { get; set; }

        public AddLineModel(PricesService pricesService)
        {
            _pricesService = pricesService;
        }

        public void OnGet()
        {
            Price = _pricesService.GetPrice(PriceId);
        }
    }
}
