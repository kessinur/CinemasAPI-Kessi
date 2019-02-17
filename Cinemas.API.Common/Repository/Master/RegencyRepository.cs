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
    public class RegencyRepository : IRegencyRepository
    {
        MyContext myContext = new MyContext();
        Regency regency = new Regency();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Regency getRegency = Get(Id);
            getRegency.IsDelete = true;
            getRegency.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Regency> Get()
        {
            var getRegency = myContext.Regencies.Where(x => x.IsDelete == false).ToList();
            return getRegency;
        }

        public Regency Get(int? Id)
        {
            var getRegency = myContext.Regencies.Find(Id);
            return getRegency;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            var result = 0;
            regency.Name = regencyParam.Name;
            regency.Provinces = myContext.Provinces.Find(regencyParam.Provinces_Id);
            regency.CreateDate = DateTimeOffset.Now.LocalDateTime;
            regency.IsDelete = false;
            myContext.Regencies.Add(regency);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, RegencyParam regencyParam)
        {
            var result = 0;
            Regency getRegency = Get(Id);
            getRegency.Name = regencyParam.Name;
            getRegency.Provinces = myContext.Provinces.Find(regencyParam.Provinces_Id);
            getRegency.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
