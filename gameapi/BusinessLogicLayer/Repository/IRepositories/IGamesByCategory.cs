using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepositories
{
    public interface IGamesByCategory<T>:IRepository<T> where T : class
    {
        Task<List<GameDTO>> GetById(int id);
    }
}
