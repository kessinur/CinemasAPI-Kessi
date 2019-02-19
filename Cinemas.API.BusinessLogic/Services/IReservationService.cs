﻿using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IReservationService
    {
        bool Insert(ReservationParam reservationParam);
        bool Update(int? Id, ReservationParam reservationParam);
        bool Delete(int? Id);
        List<Reservation> Get();
        Reservation Get(int? Id);
    }
}
