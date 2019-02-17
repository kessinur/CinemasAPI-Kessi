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
    public class SubDistrictService : ISubDistrictService
    {
        private readonly ISubDistrictRepository _subdistrictRepository;

        public SubDistrictService(ISubDistrictRepository subdistrictRepository)
        {
            _subdistrictRepository = subdistrictRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _subdistrictRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<SubDistrict> Get()
        {
            return _subdistrictRepository.Get();
        }

        public SubDistrict Get(int? Id)
        {
            return _subdistrictRepository.Get(Id);
        }

        public bool Insert(SubDistrictParam subdistrictParam)
        {
            _subdistrictRepository.Insert(subdistrictParam);
            return status = true;
        }

        public bool Update(int? Id, SubDistrictParam subdistrictParam)
        {
            _subdistrictRepository.Update(Id, subdistrictParam);
            return status = true;
        }
    }
}
