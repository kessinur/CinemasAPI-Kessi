using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class ProductParam
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Restaurants_Id { get; set; }
    }
}
