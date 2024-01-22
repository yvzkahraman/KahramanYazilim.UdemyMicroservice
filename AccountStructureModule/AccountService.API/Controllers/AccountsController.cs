using AccountService.API.Dtos;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PlayerRepository playerRepository;

        public AccountsController(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto dto)
        {
            var result = await playerRepository.Create(new Data.Entities.Player
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
            });
            return Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await playerRepository.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlayerUpdateDto dto)
        {
            await playerRepository.Update(new Data.Entities.Player { FirstName = dto.FirstName, LastName = dto.LastName, Username = dto.Username, Id = dto.Id });

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await playerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await playerRepository.GetById(id);
            return Ok(result);
        }
    }
}
