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
    public class ProvincesController : ApiController
    {
        private readonly IProvinceService _provinceService;
        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        // GET: api/Provincies
        public IEnumerable<Province> Get()
        {
            return _provinceService.Get();
        }

        // GET: api/Provincies/5
        public Province Get(int id)
        {
            return _provinceService.Get(id);
        }

        // POST: api/Provincies
        public void Post(ProvinceParam provinceParam)
        {
            _provinceService.Insert(provinceParam);
        }

        // PUT: api/Provincies/5
        public void Put(int id, ProvinceParam provinceParam)
        {
            _provinceService.Update(id, provinceParam);
        }

        // DELETE: api/Provincies/5
        public void Delete(int id)
        {
            _provinceService.Delete(id);
        }
    }
}
