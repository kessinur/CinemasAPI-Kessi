using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.DataAccess.Context;
using Cinemas.API.DataAccess.Model.TransactionMaster;
using Cinemas.API.DataAccess.Param.TransactionMaster;

namespace Cinemas.API.Common.Repository.Master
{
    public class ReservationRepository : IReservationRepository
    {
        MyContext myContext = new MyContext();
        Reservation reservation = new Reservation();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Reservation getReservation = Get(Id);
            getReservation.IsDelete = true;
            getReservation.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Reservation> Get()
        {
            var getReservation = myContext.Reservations.Where(x => x.IsDelete == false).ToList();
            return getReservation;
        }

        public Reservation Get(int? Id)
        {
            var getReservation = myContext.Reservations.Find(Id);
            return getReservation;
        }

        public bool Insert(ReservationParam reservationParam)
        {
            var result = 0;
            reservation.ReservationDate = DateTimeOffset.Now.LocalDateTime;
            reservation.TotalPrice = reservationParam.TotalPrice;
            reservation.Users = myContext.Users.Find(reservationParam.Users_Id);
            reservation.CreateDate = DateTimeOffset.Now.LocalDateTime;
            reservation.IsDelete = false;
            myContext.Reservations.Add(reservation);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
