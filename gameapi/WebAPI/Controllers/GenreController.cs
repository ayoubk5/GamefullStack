using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Repository.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGamesByCategory<GenreDTO> _repository;
        public GenreController(IGamesByCategory<GenreDTO> repository)
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

            var genre = await _repository.GetById(Id);
            if (genre == null)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Genre Not Exist ",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            return Ok(genre);
        }


    }
}
