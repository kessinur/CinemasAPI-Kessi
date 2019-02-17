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
    public class TheaterRepository : ITheaterRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Theater theater = Get(Id);
            theater.IsDelete = true;
            theater.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Theater> Get()
        {
            var get = myContext.Theaters.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Theater Get(int? Id)
        {
            Theater theater = myContext.Theaters.Where(x => x.Id == Id).SingleOrDefault();
            return theater;
        }

        public bool Insert(TheaterParam theaterParam)
        {
            var result = 0;
            var theater = new Theater();
            theater.Name = theaterParam.Name;
            theater.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Theaters.Add(theater);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int? Id, TheaterParam theaterParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = theaterParam.Name;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
