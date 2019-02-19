using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _userRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<User> Get()
        {
            return _userRepository.Get();
        }

        public User Get(int? Id)
        {
            return _userRepository.Get(Id);
        }

        public bool Insert(UserParam userParam)
        {
            _userRepository.Insert(userParam);
            return status = true;
        }

        public bool Update(int? Id, UserParam userParam)
        {
            _userRepository.Update(Id, userParam);
            return status = true;
        }
    }
}
