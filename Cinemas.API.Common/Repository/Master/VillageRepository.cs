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
    public class VillageRepository : IVillageRepository
    {
        MyContext myContext = new MyContext();
        Village village = new Village();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Village getVillage = Get(Id);
            getVillage.IsDelete = true;
            getVillage.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Village> Get()
        {
            var getVillage = myContext.Villages.Where(x => x.IsDelete == false).ToList();
            return getVillage;
        }

        public Village Get(int? Id)
        {
            var getVillage = myContext.Villages.Find(Id);
            return getVillage;
        }

        public bool Insert(VillageParam villageParam)
        {
            var result = 0;
            village.Name = villageParam.Name;
            village.SubDistricts = myContext.SubDistricts.Find(villageParam.SubDistricts_Id);
            village.CreateDate = DateTimeOffset.Now.LocalDateTime;
            village.IsDelete = false;
            myContext.Villages.Add(village);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, VillageParam villageParam)
        {
            var result = 0;
            Village getVillage = Get(Id);
            getVillage.Name = villageParam.Name;
            getVillage.SubDistricts = myContext.SubDistricts.Find(villageParam.SubDistricts_Id);
            getVillage.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Village> GetVillage(int? Id)
        {
            return myContext.Villages.Where(x => x.SubDistricts.Id == Id && x.IsDelete == false).ToList();
        }
    }
}
