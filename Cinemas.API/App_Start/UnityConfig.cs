using Cinemas.API.BusinessLogic.Services;
using Cinemas.API.BusinessLogic.Services.Master;
using Cinemas.API.Common.Repository;
using Cinemas.API.Common.Repository.Master;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Cinemas.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //this is Service Area
            container.RegisterType<IRegencyService, RegencyService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<ISubDistrictService, SubDistrictService>();
            container.RegisterType<IVillageService, VillageService>();
            container.RegisterType<ITheaterService, TheaterService>();
            container.RegisterType<ICinemaService, CinemaService>();
            container.RegisterType<IRestaurantService, RestaurantService>();
            container.RegisterType<IRoomService, RoomService>();

            //this is Repository Area
            container.RegisterType<IRegencyRepository, RegencyRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<ISubDistrictRepository, SubDistrictRepository>();
            container.RegisterType<IVillageRepository, VillageRepository>();
            container.RegisterType<ITheaterRepository, TheaterRepository>();
            container.RegisterType<ICinemaRepository, CinemaRepository>();
            container.RegisterType<IRestaurantRepository, RestaurantRepository>();
            container.RegisterType<IRoomRepository, RoomRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}