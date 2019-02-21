using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param.Transactions
{
    public class BuyTicketParam
    {
        public int Reservations_Id { get; set; }
        public int FilmRooms_Id { get; set; }
    }
}
