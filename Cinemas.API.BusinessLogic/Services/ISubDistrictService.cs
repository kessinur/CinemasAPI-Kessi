using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface ISubDistrictService
    {
        bool Insert(SubDistrictParam subdistrictParam);
        bool Update(int? Id, SubDistrictParam subdistrictParam);
        bool Delete(int? Id);
        List<SubDistrict> Get();
        SubDistrict Get(int? Id);
    }
}
