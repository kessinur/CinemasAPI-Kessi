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
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        // GET: api/Restaurants
        public IEnumerable<Restaurant> Get()
        {
            return _restaurantService.Get();
        }

        // GET: api/Restaurants/5
        public Restaurant Get(int id)
        {
            return _restaurantService.Get(id);
        }

        // POST: api/Restaurants
        public void Post(RestaurantParam restaurantParam)
        {
            _restaurantService.Insert(restaurantParam);
        }

        // PUT: api/Restaurants/5
        public void Put(int id, RestaurantParam restaurantParam)
        {
            _restaurantService.Update(id, restaurantParam);
        }

        // DELETE: api/Restaurants/5
        public void Delete(int id)
        {
            _restaurantService.Delete(id);
        }
    }
}
