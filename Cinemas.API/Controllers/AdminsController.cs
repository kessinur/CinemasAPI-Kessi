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
    public class AdminsController : ApiController
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: api/Admins
        public IEnumerable<Admin> Get()
        {
            return _adminService.Get();
        }

        // GET: api/Admins/5
        public Admin Get(int id)
        {
            return _adminService.Get(id);
        }

        // POST: api/Admins
        public void Post(AdminParam adminParam)
        {
            _adminService.Insert(adminParam);
        }

        // PUT: api/Admins/5
        public void Put(int id, AdminParam adminParam)
        {
            _adminService.Update(id, adminParam);
        }

        // DELETE: api/Admins/5
        public void Delete(int id)
        {
            _adminService.Delete(id);
        }
    }
}
