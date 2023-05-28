using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class MappingProfile:Profile
    {
        private readonly AppDBContext _dbContext;

        
        public MappingProfile(AppDBContext dbContext)
        {
            _dbContext = dbContext;

            CreateMap<Game, GameDTO>()
                .ForMember(obj => obj.Platformes, 
                opt => opt.MapFrom(src => _dbContext.GamePlatformes
                .Include(w => w.Platforme)
                .Where(x => x.GameId == src.Id)
                .Select(w => w.Platforme)
                .ToList()))
                .ReverseMap();

            CreateMap<Platforme, PlatformeDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();  
        }
    }
}
