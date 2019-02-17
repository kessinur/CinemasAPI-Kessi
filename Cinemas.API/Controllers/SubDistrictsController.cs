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
    public class SubDistrictsController : ApiController
    {
        private readonly ISubDistrictService _subdistrictService;

        public SubDistrictsController(ISubDistrictService subdistrictService)
        {
            _subdistrictService = subdistrictService;
        }
        // GET: api/SubDistricts
        public IEnumerable<SubDistrict> Get()
        {
            return _subdistrictService.Get();
        }

        // GET: api/SubDistricts/5
        public SubDistrict Get(int id)
        {
            return _subdistrictService.Get(id);
        }

        // POST: api/SubDistricts
        public void Post(SubDistrictParam subdistrictParam)
        {
            _subdistrictService.Insert(subdistrictParam);
        }

        // PUT: api/SubDistricts/5
        public void Put(int id, SubDistrictParam subdistrictParam)
        {
            _subdistrictService.Update(id, subdistrictParam);
        }

        // DELETE: api/SubDistricts/5
        public void Delete(int id)
        {
            _subdistrictService.Delete(id);
        }
    }
}
