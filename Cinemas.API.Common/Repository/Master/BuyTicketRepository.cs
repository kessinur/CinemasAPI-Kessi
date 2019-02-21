using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model.Transactions;
using Cinemas.API.DataAccess.Param.Transactions;
using Cinemas.API.DataAccess.Context;

namespace Cinemas.API.Common.Repository.Master
{
    public class BuyTicketRepository : IBuyTicketRepository
    {
        MyContext myContext = new MyContext();
        BuyTicket buyticket = new BuyTicket();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            BuyTicket getBuyTicket = Get(Id);
            getBuyTicket.IsDelete = true;
            getBuyTicket.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<BuyTicket> Get()
        {
            var getBuyTicket = myContext.BuyTickets.Where(x => x.IsDelete == false).ToList();
            return getBuyTicket;
        }

        public BuyTicket Get(int? Id)
        {
            var getBuyTicket = myContext.BuyTickets.Find(Id);
            return getBuyTicket;
        }

        public bool Insert(BuyTicketParam buyticketParam)
        {
            var result = 0;
            buyticket.FilmRooms = myContext.FilmRooms.Find(buyticketParam.FilmRooms_Id);
            buyticket.Reservations = myContext.Reservations.Find(buyticketParam.Reservations_Id);
            buyticket.CreateDate = DateTimeOffset.Now.LocalDateTime;
            buyticket.IsDelete = false;

            myContext.BuyTickets.Add(buyticket);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
