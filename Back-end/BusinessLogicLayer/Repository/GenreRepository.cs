using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Repository.IRepositories;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class GenreRepository : IGamesByCategory<GenreDTO>
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public GenreRepository(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<List<GenreDTO>> GetAll()
        {
        
            return _mapper.Map<List<Genre>, List<GenreDTO>>(_dBContext.Genres.ToList());
        }

        public async Task<List<GameDTO>> GetById(int id)
        {
            var Obj =  _dBContext.Games.Where(x => x.GenreId == id).ToList();
            if (Obj != null)
            {

                return _mapper.Map<List<Game>, List<GameDTO>>(Obj);
            }
            return null;
        }
    }
}
