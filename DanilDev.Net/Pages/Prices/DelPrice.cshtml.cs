using DanilDev.Services.Prices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.Prices
{
    [IgnoreAntiforgeryToken]
    public class DelPriceModel : PageModel
    {
        private readonly PricesService _pricesService;

        public DelPriceModel(PricesService pricesService)
        {
            _pricesService = pricesService;
        }

        public void OnGet()
        {
        }

        public RedirectResult OnPost(
            long priceToDelId,
            string referrer)
        {
            _pricesService.DeletePrice(priceToDelId);
            return Redirect(referrer);
        }
    }
}
