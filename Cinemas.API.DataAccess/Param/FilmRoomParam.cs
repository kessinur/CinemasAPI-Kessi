using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class FilmRoomParam
    {
        public DateTime ShowDate { get; set; }
        public string Hour { get; set; }
        public int Price { get; set; }
        public int Films_Id { get; set; }
        public int Rooms_Id { get; set; }
    }
}
