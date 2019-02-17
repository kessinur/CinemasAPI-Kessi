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
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _cinemaRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Cinema> Get()
        {
            return _cinemaRepository.Get();
        }

        public Cinema Get(int? Id)
        {
            return _cinemaRepository.Get(Id);
        }

        public bool Insert(CinemaParam cinemaParam)
        {
            _cinemaRepository.Insert(cinemaParam);
            return status = true;
        }

        public bool Update(int? Id, CinemaParam cinemaParam)
        {
            _cinemaRepository.Update(Id, cinemaParam);
            return status = true;
        }
    }
}
