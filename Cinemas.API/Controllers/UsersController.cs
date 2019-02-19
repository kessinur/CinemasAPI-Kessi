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
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        // GET: api/Users/5
        public User Get(int id)
        {
            return _userService.Get(id);
        }

        // POST: api/Users
        public void Post(UserParam userParam)
        {
            _userService.Insert(userParam);
        }

        // PUT: api/Users/5
        public void Put(int id, UserParam userParam)
        {
            _userService.Update(id, userParam);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
