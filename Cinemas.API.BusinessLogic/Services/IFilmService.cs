using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IFilmService
    {
        bool Insert(FilmParam filmParam);
        bool Update(int? Id, FilmParam filmParam);
        bool Delete(int? Id);
        List<Film> Get();
        Film Get(int? Id);
    }
}
