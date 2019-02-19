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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
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
                status = _adminRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Admin> Get()
        {
            return _adminRepository.Get();
        }

        public Admin Get(int? Id)
        {
            var getAdminId = _adminRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getAdminId;
        }

        public bool Insert(AdminParam adminParam)
        {
            if (adminParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _adminRepository.Insert(adminParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, AdminParam adminParam)
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
                status = _adminRepository.Update(Id, adminParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
