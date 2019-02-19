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
    public class ReligionsController : ApiController
    {
        private readonly IReligionService _religionService;
        public ReligionsController(IReligionService religionService)
        {
            _religionService = religionService;
        }

        // GET: api/Religions
        public IEnumerable<Religion> Get()
        {
            return _religionService.Get();
        }

        // GET: api/Religions/5
        public Religion Get(int id)
        {
            return _religionService.Get(id);
        }

        // POST: api/Religions
        public void Post(ReligionParam religionParam)
        {
            _religionService.Insert(religionParam);
        }

        // PUT: api/Religions/5
        public void Put(int id, ReligionParam religionParam)
        {
            _religionService.Update(id, religionParam);
        }

        // DELETE: api/Religions/5
        public void Delete(int id)
        {
            _religionService.Delete(id);
        }
    }
}
