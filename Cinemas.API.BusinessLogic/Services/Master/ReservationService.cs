using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _reservationRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Reservation> Get()
        {
            return _reservationRepository.Get();
        }

        public Reservation Get(int? Id)
        {
            return _reservationRepository.Get(Id);
        }

        public bool Insert(ReservationParam reservationParam)
        {
            _reservationRepository.Insert(reservationParam);
            return status = true;
        }

        public bool Update(int? Id, ReservationParam reservationParam)
        {
            _reservationRepository.Update(Id, reservationParam);
            return status = true;
        }
    }
}
