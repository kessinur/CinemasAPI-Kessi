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
    public class FilmRoomService : IFilmRoomService
    {
        private readonly IFilmRoomRepository _filmRoomRepository;

        public FilmRoomService(IFilmRoomRepository filmRoomRepository)
        {
            _filmRoomRepository = filmRoomRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _filmRoomRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<FilmRoom> Get()
        {
            return _filmRoomRepository.Get();
        }

        public FilmRoom Get(int? Id)
        {
            return _filmRoomRepository.Get(Id);
        }

        public bool Insert(FilmRoomParam filmRoomParam)
        {
            _filmRoomRepository.Insert(filmRoomParam);
            return status = true;
        }

        public bool Update(int? Id, FilmRoomParam filmRoomParam)
        {
            _filmRoomRepository.Update(Id, filmRoomParam);
            return status = true;
        }
    }
}
