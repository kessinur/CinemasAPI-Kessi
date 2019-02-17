using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface ICinemaRepository 
    {
        bool Insert(CinemaParam cinemaParam);
        bool Update(int? Id, CinemaParam cinemaParam);
        bool Delete(int? Id);
        List<Cinema> Get();
        Cinema Get(int? Id);
    }
}
