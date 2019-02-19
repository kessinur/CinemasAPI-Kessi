using Cinemas.API.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model
{
    public class Reservation : BaseModel
    {
        public DateTimeOffset ReservationDate { get; set; }
        public int TotalPrice { get; set; }
    }
}
