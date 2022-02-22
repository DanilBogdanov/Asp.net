using DanilDev.Services.Prices;
using DanilDev.Services.Prices.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.Prices
{
    public class EditLineModel : PageModel
    {
        public Line Line { get; set; }
        public Price Price { get; set; }
        private readonly PricesService _pricesService;
        [BindProperty(SupportsGet = true)]
        public int LineId { get; set; }

        public EditLineModel(PricesService pricesService)
        {
            _pricesService = pricesService;
        }

        public void OnGet()
        {
            Line = _pricesService.GetLine(LineId);
            Price = _pricesService.GetPrice(Line.PriceId);
        }
    }
}
