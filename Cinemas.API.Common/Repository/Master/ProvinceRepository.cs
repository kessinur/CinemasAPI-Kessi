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
    public class ProvinceRepository : IProvinceRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Province province = Get(Id);
            province.IsDelete = true;
            province.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Province> Get()
        {
            var get = myContext.Provinces.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Province Get(int? Id)
        {
            Province province = myContext.Provinces.Where(x => x.Id == Id).SingleOrDefault();
            return province;
        }

        public bool Insert(ProvinceParam provinceParam)
        {
            var result = 0;
            var province = new Province();
            province.Name = provinceParam.Name;
            province.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Provinces.Add(province);
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

        public bool Update(int? Id, ProvinceParam provinceParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = provinceParam.Name;
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
