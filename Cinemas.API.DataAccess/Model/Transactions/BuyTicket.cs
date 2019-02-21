using Cinemas.API.Core.BaseModel;
using Cinemas.API.DataAccess.Model.TransactionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Model.Transactions
{
    public class BuyTicket : BaseModel
    {
        public virtual Reservation Reservations { get; set; }
        public virtual FilmRoom FilmRooms { get; set; }
    } 
}
