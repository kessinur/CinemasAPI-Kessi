using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class CinemaParam
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Villages_Id { get; set; }
        public int Theaters_Id { get; set; }
    }
}
