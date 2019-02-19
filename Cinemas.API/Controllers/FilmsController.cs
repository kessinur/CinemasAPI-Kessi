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
    public class FilmsController : ApiController
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        // GET: api/Films
        public IEnumerable<Film> Get()
        {
            return _filmService.Get();
        }

        // GET: api/Films/5
        public Film Get(int id)
        {
            return _filmService.Get(id);        }

        // POST: api/Films
        public void Post(FilmParam filmParam)
        {
            _filmService.Insert(filmParam);
        }

        // PUT: api/Films/5
        public void Put(int id, FilmParam filmParam)
        {
            _filmService.Update(id, filmParam);
        }

        // DELETE: api/Films/5
        public void Delete(int id)
        {
            _filmService.Delete(id);
        }
    }
}
