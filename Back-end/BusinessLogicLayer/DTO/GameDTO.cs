
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public List<PlatformeDTO> Platformes { get; set; }=new List<PlatformeDTO>();
        public int GenreId { get; set; }
        
    }
}
