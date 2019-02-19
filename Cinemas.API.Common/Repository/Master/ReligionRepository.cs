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
    public class ReligionRepository : IReligionRepository
    {
        MyContext myContext = new MyContext();
        Religion religion = new Religion();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Religion getReligion = Get(Id);
            getReligion.IsDelete = true;
            getReligion.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Religion> Get()
        {
            var getReligion = myContext.Religions.Where(x => x.IsDelete == false).ToList();
            return getReligion;
        }

        public Religion Get(int? Id)
        {
            var getReligion = myContext.Religions.Find(Id);
            return getReligion;
        }

        public bool Insert(ReligionParam religionParam)
        {
            var result = 0;
            religion.Name = religionParam.Name;
            religion.CreateDate = DateTimeOffset.Now.LocalDateTime;
            religion.IsDelete = false;
            myContext.Religions.Add(religion);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, ReligionParam religionParam)
        {
            var result = 0;
            Religion getReligion = Get(Id);
            getReligion.Name = religionParam.Name;
            getReligion.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
