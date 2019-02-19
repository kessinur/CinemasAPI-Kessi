using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class ReservationParam
    {
        public DateTimeOffset ReservationDate { get; set; }
        public int TotalPrice { get; set; }
    }
}
