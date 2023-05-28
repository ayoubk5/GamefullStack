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
    public class PlatformeRepository : IGamesByCategory<PlatformeDTO>
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public PlatformeRepository(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<List<PlatformeDTO>> GetAll()
        {
            return _mapper.Map<List<Platforme>, List<PlatformeDTO>>(_dBContext.Platformes.ToList()); 
        }

        public async Task<List<GameDTO>> GetById(int id)
        {
            var Obj = _dBContext.GamePlatformes.Include(x=>x.Game).Where(x=>x.PlatformId == id).Select(x=>x.Game).ToList();

            if (Obj != null)
            {
                return _mapper.Map<List<Game>, List<GameDTO>>(Obj);
            }
            return null;
        }
    }
}
