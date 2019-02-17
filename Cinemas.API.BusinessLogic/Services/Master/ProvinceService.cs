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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        bool status = false;
        public bool Delete(int? Id)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _provinceRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Province> Get()
        {
            return _provinceRepository.Get();
        }

        public Province Get(int? Id)
        {
            var getProvinceId = _provinceRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getProvinceId;
        }

        public bool Insert(ProvinceParam provinceParam)
        {
            if (provinceParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _provinceRepository.Insert(provinceParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, ProvinceParam provinceParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _provinceRepository.Update(Id, provinceParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
