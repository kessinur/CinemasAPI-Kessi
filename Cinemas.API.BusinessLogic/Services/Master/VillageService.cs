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
    public class VillageService : IVillageService
    {
        private readonly IVillageRepository _villageRepository;

        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _villageRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Village> Get()
        {
            return _villageRepository.Get();
        }

        public Village Get(int? Id)
        {
            return _villageRepository.Get(Id);
        }

        public bool Insert(VillageParam villageParam)
        {
            _villageRepository.Insert(villageParam);
            return status = true;
        }

        public bool Update(int? Id, VillageParam villageParam)
        {
            _villageRepository.Update(Id, villageParam);
            return status = true;
        }

        public List<Village> GetVillage(int? Id)
        {
            return _villageRepository.GetVillage(Id);
        }
    }
}
