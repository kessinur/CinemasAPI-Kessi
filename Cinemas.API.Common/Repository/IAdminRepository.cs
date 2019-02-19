﻿using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface IAdminRepository
    {
        bool Insert(AdminParam adminParam);
        bool Update(int? Id, AdminParam adminParam);
        bool Delete(int? Id);
        List<Admin> Get();
        Admin Get(int? Id);
    }
}
