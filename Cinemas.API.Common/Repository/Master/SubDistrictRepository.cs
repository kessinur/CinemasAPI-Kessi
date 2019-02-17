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
    public class SubDistrictRepository : ISubDistrictRepository
    {
        MyContext myContext = new MyContext();
        SubDistrict subdistrict = new SubDistrict();
        bool status = true;
        public bool Delete(int? Id)
        {
            var result = 0;
            SubDistrict getSubDistrict = Get(Id);
            getSubDistrict.IsDelete = true;
            getSubDistrict.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<SubDistrict> Get()
        {
            var getSubDistrict = myContext.SubDistricts.Where(x => x.IsDelete == false).ToList();
            return getSubDistrict;
        }

        public SubDistrict Get(int? Id)
        {
            var getSubDistrict = myContext.SubDistricts.Find(Id);
            return getSubDistrict;
        }

        public bool Insert(SubDistrictParam subdistrictParam)
        {
            var result = 0;
            subdistrict.Name = subdistrictParam.Name;
            subdistrict.Regencies = myContext.Regencies.Find(subdistrictParam.Regencies_Id);
            subdistrict.CreateDate = DateTimeOffset.Now.LocalDateTime;
            subdistrict.IsDelete = false;
            myContext.SubDistricts.Add(subdistrict);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, SubDistrictParam subdistrictParam)
        {
            var result = 0;
            SubDistrict getSubDistrict = Get(Id);
            getSubDistrict.Name = subdistrictParam.Name;
            getSubDistrict.Regencies = myContext.Regencies.Find(subdistrictParam.Regencies_Id);
            getSubDistrict.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
