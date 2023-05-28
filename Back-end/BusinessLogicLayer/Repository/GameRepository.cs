using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BusinessLogicLayer.Repository.IRepositories;

namespace BusinessLogicLayer.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public GameRepository(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<GameDTO> Create(GameDTO objGameDto)
        {
            try
            {
                var objGame = new Game
                {
                    Name = objGameDto.Name,
                    Slug = objGameDto.Name.ToLower(),
                    GenreId = objGameDto.GenreId,
                    Rating = objGameDto.Rating,
                    Image = objGameDto.Image,
                };
                 _dBContext.Games.Add(objGame);
                await _dBContext.SaveChangesAsync();
                var listplatforme=new List<GamePlatformes>();
                foreach (var item in objGameDto.Platformes)
                {
                    listplatforme.Add(new GamePlatformes { GameId = objGame.Id, PlatformId = item.Id });
                }
                await _dBContext.GamePlatformes.BulkInsertAsync(listplatforme);
                await _dBContext.SaveChangesAsync();
                var gameDto= _mapper.Map<Game, GameDTO>(objGame);
                return gameDto;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var Obj = await _dBContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (Obj != null)
            {
                _dBContext.Games.Remove(Obj);
                await _dBContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<GameDTO>> GetAll()
        {
             var games=  _mapper.Map<List<Game>, List<GameDTO>>(_dBContext.Games.Include(u => u.GamePlatformes).ToList());
            
            return games;
        }

        public async Task<GameDTO> GetById(int id)
        {
            var Obj = await _dBContext.Games
                .Include(u => u.GamePlatformes)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (Obj != null)
            {
                var gameDto = _mapper.Map<Game, GameDTO>(Obj);
                  
                return gameDto;
            }
            return null;
        }

        public async Task<List<GameDTO>> SearchAsync(string Name)
        {
            var games = _mapper.Map<List<Game>, List<GameDTO>>(_dBContext.Games
                .Include(u => u.GamePlatformes)
                .Where(x=>x.Name.Contains(Name))
                .ToList());
            if(games.Count != 0)
                return games;
            return new List<GameDTO>();
        }

        public async Task<GameDTO> Update(GameDTO game)
        {
            var Obj = await _dBContext.Games.Include(x=>x.GamePlatformes).FirstOrDefaultAsync(x => x.Id == game.Id);
            if (Obj != null)
            {
                _mapper.Map(game, Obj);
                Obj.GamePlatformes.Clear();
                await _dBContext.SaveChangesAsync();
                var listplatforme = new List<GamePlatformes>();
                foreach (var item in game.Platformes)
                {
                    listplatforme.Add(new GamePlatformes { GameId = Obj.Id, PlatformId = item.Id });
                }
                await _dBContext.GamePlatformes.BulkInsertAsync(listplatforme);
                await _dBContext.SaveChangesAsync();
                var gameDto = _mapper.Map<Game, GameDTO>(Obj);
                return gameDto;
            }

            return null;
        }
    }
}
