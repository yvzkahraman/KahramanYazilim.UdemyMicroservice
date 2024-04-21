using InventoryService.API.Dtos;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepository;
        public InventoriesController(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            var list = await _inventoryRepository.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _inventoryRepository.GetById(id); 
            return Ok(result);
        }

        [HttpPost]
        public async  Task<IActionResult> Create(InventoryCreateDto dto)
        {
            var result = await _inventoryRepository.Create(new Data.Entities.Inventory
            {
                PlayerId =dto.PlayerId,
                Name =dto.Name,
            });
            return Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _inventoryRepository.Remove(id);
            return NoContent();
        }
    }
}
