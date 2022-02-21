using DanilDev.Services.Prices;
using DanilDev.Services.Prices.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DanilDev.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly PricesService _pricesService;
        public PricesController(PricesService pricesService)
        {
            _pricesService = pricesService;
        }

        [HttpGet("getPrices")]
        public IEnumerable<Price> GetPrices()
        {
            var prices = _pricesService.GetPrices();
            return prices;
        }

        [HttpGet("getPricesCount")]
        public int GetPricesCount()
        {
            var pricesCount = _pricesService.GetPrices().Count;
            return pricesCount;
        }

        [HttpPost("addPrice")]
        public void AddPrice([FromForm]Price price)
        {
            if (price.Name != null)
            {
                _pricesService.AddPrice(price);
            }
        }

        [HttpGet("getPrice/{id}")]
        public ActionResult<Price> GetPrice(long id)
        {
            return _pricesService.GetPrice(id);
        }
    }
}
