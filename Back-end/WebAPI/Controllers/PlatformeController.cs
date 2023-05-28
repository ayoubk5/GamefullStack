using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Repository.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformeController : ControllerBase
    {
        private readonly IGamesByCategory<PlatformeDTO> _repository;
        public PlatformeController(IGamesByCategory<PlatformeDTO> repository)
        {
            _repository = repository;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _repository.GetAll());
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGenre(int Id)
        {
            if (Id == null || Id == 0)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid ID",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            var platforme = await _repository.GetById(Id);
            if (platforme == null)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Platforme Not Exist ",
                    StatusCode = StatusCodes.Status404NotFound
                });

            return Ok(platforme);
        }
    }
}
