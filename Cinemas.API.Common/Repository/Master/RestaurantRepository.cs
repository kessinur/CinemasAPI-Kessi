using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.DataAccess.Context;

namespace Cinemas.API.Common.Repository.Master
{
    public class RestaurantRepository : IRestaurantRepository
    {
        MyContext myContext = new MyContext();
        Restaurant restaurant = new Restaurant();
        bool status = true;
        public bool Delete(int? Id)
        {
            var result = 0;
            Restaurant getRestaurant = Get(Id);
            getRestaurant.IsDelete = true;
            getRestaurant.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Restaurant> Get()
        {
            var getRestaurant = myContext.Restaurants.Where(x => x.IsDelete == false).ToList();
            return getRestaurant;
        }

        public Restaurant Get(int? Id)
        {
            var getRestaurant = myContext.Restaurants.Find(Id);
            return getRestaurant;
        }

        public bool Insert(RestaurantParam restaurantParam)
        {
            var result = 0;
            restaurant.Name = restaurantParam.Name;
            restaurant.Description = restaurantParam.Description;
            restaurant.Cinemas = myContext.Cinemas.Find(restaurantParam.Cinemas_Id);
            restaurant.CreateDate = DateTimeOffset.Now.LocalDateTime;
            restaurant.IsDelete = false;
            myContext.Restaurants.Add(restaurant);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, RestaurantParam restaurantParam)
        {
            var result = 0;
            Restaurant getRestaurant = Get(Id);
            getRestaurant.Name = restaurantParam.Name;
            getRestaurant.Description = restaurantParam.Description;
            getRestaurant.Cinemas = myContext.Cinemas.Find(restaurantParam.Cinemas_Id);
            getRestaurant.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
