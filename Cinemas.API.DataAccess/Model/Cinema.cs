using Cinemas.API.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model
{
    public class Cinema : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual Village Villages { get; set; }
        public virtual Theater Theaters { get; set; }
    }
}
