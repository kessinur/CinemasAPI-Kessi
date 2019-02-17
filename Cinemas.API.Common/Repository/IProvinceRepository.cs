using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface IProvinceRepository
    {
        bool Insert(ProvinceParam provinceParam);
        bool Update(int? Id, ProvinceParam provinceParam);
        bool Delete(int? Id);
        List<Province> Get();
        Province Get(int? Id);
    }
}
