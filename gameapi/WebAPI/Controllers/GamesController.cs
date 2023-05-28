using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Repository.IRepositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _repository;
        public GamesController(IGameRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpGet("Search/{Name}")]
        public async Task<IActionResult> SearchGames(string Name)
        {
            if(string.IsNullOrWhiteSpace(Name))
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Name",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            var games = await _repository.SearchAsync(Name);
            if (games == null)
                return NotFound(new ErrorModelDTO()
                {
                    ErrorMessage = "Not Exist ",
                    StatusCode = StatusCodes.Status204NoContent
                });
            return Ok(games);
            
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGame(int Id)
        {
            if (Id == null || Id == 0)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid ID",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            var ObjGame = await _repository.GetById(Id);
            if (ObjGame == null)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Game Not Exist ",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            return Ok(ObjGame);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddGame([FromBody] GameDTO game)
        {
            var res = await _repository.Create(game);

            if (res == null)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Operation Failed, can't create the game",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            return Ok(new SuccessModelDTO()
            {
                SeccessMessage = "Operation success",
                StatusCode = StatusCodes.Status200OK,
                Data = res
            });
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteGame(int Id)
        {
            if (Id == 0)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid ID",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            var res = await _repository.Delete(Id);

            if (!res)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Operation Failed, can't Delete the game",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            return Ok(new SuccessModelDTO()
            {
                SeccessMessage = "Operation success",
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGame([FromBody] GameDTO game)
        {
            if (game.Id == 0)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid ID",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            var ObjGame = await _repository.Update(game);
            if (ObjGame == null)
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Product  Not Exist ",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            return Ok(ObjGame);
        }
    }
}
