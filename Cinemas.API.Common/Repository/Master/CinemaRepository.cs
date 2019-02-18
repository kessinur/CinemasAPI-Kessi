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
    public class CinemaRepository : ICinemaRepository
    {
        MyContext myContext = new MyContext();
        Cinema cinema = new Cinema();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Cinema getCinema = Get(Id);
            getCinema.IsDelete = true;
            getCinema.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Cinema> Get()
        {
            var getCinema = myContext.Cinemas.Where(x => x.IsDelete == false).ToList();
            return getCinema;
        }

        public Cinema Get(int? Id)
        {
            var getCinema = myContext.Cinemas.Find(Id);
            return getCinema;
        }

        public bool Insert(CinemaParam cinemaParam)
        {
            var result = 0;
            cinema.Name = cinemaParam.Name;
            cinema.Address = cinemaParam.Address;
            cinema.Villages = myContext.Villages.Find(cinemaParam.Villages_Id);
            cinema.Theaters = myContext.Theaters.Find(cinemaParam.Theaters_Id);
            cinema.CreateDate = DateTimeOffset.Now.LocalDateTime;
            cinema.IsDelete = false;
            myContext.Cinemas.Add(cinema);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, CinemaParam cinemaParam)
        {
            var result = 0;
            Cinema getCinema = Get(Id);
            getCinema.Name = cinemaParam.Name;
            getCinema.Address = cinemaParam.Address;
            getCinema.Villages = myContext.Villages.Find(cinemaParam.Villages_Id);
            getCinema.Theaters = myContext.Theaters.Find(cinemaParam.Theaters_Id);
            getCinema.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
