using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface ITheaterRepository
    {
        bool Insert(TheaterParam theaterParam);
        bool Update(int? Id, TheaterParam theaterParam);
        bool Delete(int? Id);
        List<Theater> Get();
        Theater Get(int? Id);
    }
}
