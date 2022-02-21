using DanilDev.Services.Prices;
using DanilDev.Services.Prices.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.Prices
{
    [IgnoreAntiforgeryToken]
    public class AddPriceModel : PageModel
    {

        public AddPriceModel(PricesService priceService)
        {
        }

        public void OnGet()
        {
            
        }        
    }
}
