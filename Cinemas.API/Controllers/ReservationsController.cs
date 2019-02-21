using Cinemas.API.BusinessLogic.Services;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Model.TransactionMaster;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.DataAccess.Param.TransactionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cinemas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservationsController : ApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        // GET: api/Reservations
        public IEnumerable<Reservation> Get()
        {
            return _reservationService.Get();
        }

        // GET: api/Reservations/5
        public Reservation Get(int id)
        {
            return _reservationService.Get(id);
        }

        // POST: api/Reservations
        public void Post(ReservationParam reservationParam)
        {
            _reservationService.Insert(reservationParam);
        }

        // PUT: api/Reservations/5

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
            _reservationService.Delete(id);
        }
    }
}
