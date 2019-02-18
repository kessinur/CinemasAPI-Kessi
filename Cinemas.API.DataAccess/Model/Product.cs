using Cinemas.API.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public virtual Restaurant Restaurants { get; set; }
    }
}
