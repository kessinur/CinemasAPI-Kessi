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
    public class AdminRepository : IAdminRepository
    {
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Admin admin = Get(Id);
            admin.IsDelete = true;
            admin.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Admin> Get()
        {
            var get = myContext.Admin.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Admin Get(int? Id)
        {
            Admin admin = myContext.Admin.Where(x => x.Id == Id).SingleOrDefault();
            return admin;
        }

        public bool Insert(AdminParam adminParam)
        {
            var result = 0;
            var admin = new Admin();
            admin.Username = adminParam.Username;
            admin.Password = adminParam.Password;
            admin.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Admin.Add(admin);
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

        public Admin Login(string username, string password)
        {
            return myContext.Admin.Where(x => (x.IsDelete == false) && (x.Username == username) && (x.Password == password)).SingleOrDefault();
        }

        public bool Update(int? Id, AdminParam adminParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Username = adminParam.Username;
            get.Password = adminParam.Password;
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
