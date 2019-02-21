using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IRegencyService
    {
        bool Insert(RegencyParam regencyParam);
        bool Update(int? Id, RegencyParam regencyParam);
        bool Delete(int? Id);
        List<Regency> Get();
        Regency Get(int? Id);
        List<Regency> GetRegency(int? Id);
    }
}
