using MarketService.API.Dtos;
using MarketService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private readonly MarketRepository _marketRepository;

        public MarketsController(MarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var result = _marketRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateMarketDto dto)
        {
            var result = _marketRepository.Add(new Data.Entities.Market
            {
                InventoryId = dto.InventoryId,
                ItemId = dto.ItemId,
                PlayerId = dto.PlayerId,
                Price = dto.Price,
            });
            return Created("", result);
        }
    }
}
