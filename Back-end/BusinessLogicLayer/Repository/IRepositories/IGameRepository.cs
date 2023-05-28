using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepositories
{
    public interface IGameRepository : IRepository<GameDTO> 
    {
        Task<GameDTO> GetById(int id);
        Task<List<GameDTO>> SearchAsync(string Name);
        Task<GameDTO> Create(GameDTO entity);
        Task<bool> Delete(int id);
        Task<GameDTO> Update(GameDTO entity);
    }

}
