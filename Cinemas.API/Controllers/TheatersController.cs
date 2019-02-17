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
    public class TheatersController : ApiController
    {
        private readonly ITheaterService _theaterService;
        public TheatersController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        // GET: api/Theaters
        public IEnumerable<Theater> Get()
        {
            return _theaterService.Get();
        }

        // GET: api/Theaters/5
        public Theater Get(int id)
        {
            return _theaterService.Get(id);
        }

        // POST: api/Theaters
        public void Post(TheaterParam theaterParam)
        {
            _theaterService.Insert(theaterParam);
        }

        // PUT: api/Theaters/5
        public void Put(int id, TheaterParam theaterParam)
        {
            _theaterService.Update(id, theaterParam);
        }

        // DELETE: api/Theaters/5
        public void Delete(int id)
        {
            _theaterService.Delete(id);
        }
    }
}
