using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IRestaurantService
    {
        bool Insert(RestaurantParam restaurantParam);
        bool Update(int? Id, RestaurantParam restaurantParam);
        bool Delete(int? Id);
        List<Restaurant> Get();
        Restaurant Get(int? Id);
    }
}
