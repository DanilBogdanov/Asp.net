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

        [HttpPost("addLine")]
        public void AddLine([FromForm]Line line)
        {
            _pricesService.AddLine(line);
        }

        [HttpPost("editLine")]
        public void EditLine([FromForm]Line line)
        {
            _pricesService.UpdateLine(line);
        }

        [HttpGet("delLine/{id}")]
        public void DelLine(long id)
        {
            _pricesService.DelLine(id);
        } 

        [HttpGet("getPrice/{id}")]
        public ActionResult<Price> GetPrice(long id)
        {
            var price = _pricesService.GetPrice(id);
            if (price != null)
            {
                var lines = _pricesService.GetLines(id);
                price.Lines = lines;
            }            
            return price;
        }
    }
}
