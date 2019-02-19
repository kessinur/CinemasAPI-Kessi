using Cinemas.API.BusinessLogic.Services;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
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
    public class FilmRoomsController : ApiController
    {
        private readonly IFilmRoomService _filmroomService;

        public FilmRoomsController(IFilmRoomService filmroomService)
        {
            _filmroomService = filmroomService;
        }
        // GET: api/FilmRooms
        public IEnumerable<FilmRoom> Get()
        {
            return _filmroomService.Get();
        }

        // GET: api/FilmRooms/5
        public FilmRoom Get(int id)
        {
            return _filmroomService.Get(id);
        }

        // POST: api/FilmRooms
        public void Post(FilmRoomParam filmroomParam)
        {
            _filmroomService.Insert(filmroomParam);
        }

        // PUT: api/FilmRooms/5
        public void Put(int id, FilmRoomParam filmroomParam)
        {
            _filmroomService.Update(id, filmroomParam);
        }

        // DELETE: api/FilmRooms/5
        public void Delete(int id)
        {
            _filmroomService.Delete(id);
        }
    }
}
