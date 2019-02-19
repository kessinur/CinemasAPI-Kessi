﻿using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface IUserRepository
    {
        bool Insert(UserParam userParam);
        bool Update(int? Id, UserParam userParam);
        bool Delete(int? Id);
        List<User> Get();
        User Get(int? Id);
    }
}
