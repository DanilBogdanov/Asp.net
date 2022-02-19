using DanilDev.Services.Prices;
using DanilDev.Services.Prices.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.Prices
{
    public class AddPriceModel : PageModel
    {
        private readonly PricesService _priceService;

        public AddPriceModel(PricesService priceService)
        {
            _priceService = priceService;
        }

        public void OnGet()
        {
        }

        public RedirectResult OnPost(
            string referrer,
            string priceName
            )
        {
            Price price = new()
            {
                Name = priceName,
                Columns = new List<Column>()
                {
                    new Column(){Name = "Column1"},
                    new Column(){Name = "Column2"},
                }
            };

            _priceService.AddPrice(price);
            return Redirect(referrer);
        }
    }
}
