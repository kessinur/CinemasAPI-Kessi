using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _restaurantRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Restaurant> Get()
        {
            return _restaurantRepository.Get();
        }

        public Restaurant Get(int? Id)
        {
            return _restaurantRepository.Get(Id);
        }

        public bool Insert(RestaurantParam restaurantParam)
        {
            _restaurantRepository.Insert(restaurantParam);
            return status = true;
        }

        public bool Update(int? Id, RestaurantParam restaurantParam)
        {
            _restaurantRepository.Update(Id, restaurantParam);
            return status = true;
        }
    }
}
