using Cinemas.API.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model
{
    public class Village : BaseModel
    {
        public string Name { get; set; }
        public virtual SubDistrict SubDistricts { get; set; }
    }
}
