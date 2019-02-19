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
    public class UserRepository : IUserRepository
    {
        MyContext myContext = new MyContext();
        User user = new User();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            User getUser = Get(Id);
            getUser.IsDelete = true;
            getUser.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<User> Get()
        {
            var getUser = myContext.Users.Where(x => x.IsDelete == false).ToList();
            return getUser;
        }

        public User Get(int? Id)
        {
            var getUser = myContext.Users.Find(Id);
            return getUser;
        }

        public bool Insert(UserParam userParam)
        {
            var result = 0;
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Gender = userParam.Gender;
            user.Phone = userParam.Phone;
            user.Email = userParam.Email;
            user.Amount = userParam.Amount;
            user.Username = userParam.Username;
            user.Password = userParam.Password;
            user.Address = userParam.Address;
            user.Religions = myContext.Religions.Find(userParam.Religions_Id);
            user.Villages = myContext.Villages.Find(userParam.Villages_Id);
            user.CreateDate = DateTimeOffset.Now.LocalDateTime;
            user.IsDelete = false;
            myContext.Users.Add(user);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, UserParam userParam)
        {
            var result = 0;
            User getUser = Get(Id);
            getUser.FirstName = userParam.FirstName;
            getUser.LastName = userParam.LastName;
            getUser.Gender = userParam.Gender;
            getUser.Phone = userParam.Phone;
            getUser.Email = userParam.Email;
            getUser.Amount = userParam.Amount;
            getUser.Username = userParam.Username;
            getUser.Password = userParam.Password;
            getUser.Address = userParam.Address;
            getUser.Religions = myContext.Religions.Find(userParam.Religions_Id);
            getUser.Villages = myContext.Villages.Find(userParam.Villages_Id);
            getUser.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
