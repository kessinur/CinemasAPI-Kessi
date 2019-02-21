using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface IVillageRepository
    {
        bool Insert(VillageParam villageParam);
        bool Update(int? Id, VillageParam villageParam);
        bool Delete(int? Id);
        List<Village> Get();
        Village Get(int? Id);
        List<Village> GetVillage(int? Id);
    }
}
