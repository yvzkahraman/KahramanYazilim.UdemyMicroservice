using InventoryService.API.Dtos;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemInventoriesController : ControllerBase
    {
        private readonly ItemInventoryRepository _itemInventoryRepository;

        public ItemInventoriesController(ItemInventoryRepository itemInventoryRepository)
        {
            _itemInventoryRepository = itemInventoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await  _itemInventoryRepository.GetAll();
            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ItemInventoryCreateDto dto)
        {
            var result = await _itemInventoryRepository.Create(new Data.Entities.ItemInventory
            {
                Count = dto.Count,
                InventoryId = dto.InventoryId,
                ItemId = dto.ItemId,
            });

            return Created("", result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(ItemInventoryUpdateDto dto)
        {
            var updatedEntity = await _itemInventoryRepository.GetItemInventory(dto.ItemId, dto.InventoryId);
            if(updatedEntity != null)
            {
                updatedEntity.Count =updatedEntity.Count - dto.Count;
                await _itemInventoryRepository.Update(updatedEntity);
                return NoContent();
            }
            return NotFound();
          
        }

    }
}
