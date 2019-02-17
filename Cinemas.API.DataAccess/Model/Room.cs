using Cinemas.API.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public int Seat { get; set; }
        public virtual Cinema Cinemas { get; set; }
    }
}
