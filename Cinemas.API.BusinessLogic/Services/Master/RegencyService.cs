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
    public class RegencyService : IRegencyService
    {
        private readonly IRegencyRepository _regencyRepository;

        public RegencyService(IRegencyRepository regencyRepository)
        {
            _regencyRepository = regencyRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _regencyRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Regency> Get()
        {
            return _regencyRepository.Get();
        }

        public Regency Get(int? Id)
        {
            return _regencyRepository.Get(Id);
        }

        public bool Insert(RegencyParam regencyParam)
        {
            _regencyRepository.Insert(regencyParam);
            return status = true;
        }

        public bool Update(int? Id, RegencyParam regencyParam)
        {
            _regencyRepository.Update(Id, regencyParam);
            return status = true;
        }

        public List<Regency> GetRegency(int? Id)
        {
            return _regencyRepository.GetRegency(Id);
        }
    }
}
