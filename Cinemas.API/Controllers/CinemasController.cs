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
    public class CinemasController : ApiController
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        // GET: api/Cinemas
        public IEnumerable<Cinema> Get()
        {
            return _cinemaService.Get();
        }

        // GET: api/Cinemas/5
        public Cinema Get(int id)
        {
            return _cinemaService.Get(id);
        }

        // POST: api/Cinemas
        public void Post(CinemaParam cinemaParam)
        {
            _cinemaService.Insert(cinemaParam);
        }

        // PUT: api/Cinemas/5
        public void Put(int id, CinemaParam cinemaParam)
        {
            _cinemaService.Update(id, cinemaParam);
        }

        // DELETE: api/Cinemas/5
        public void Delete(int id)
        {
            _cinemaService.Delete(id);
        }
    }
}
