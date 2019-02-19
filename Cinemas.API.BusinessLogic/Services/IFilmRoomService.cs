using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IFilmRoomService
    {
        bool Insert(FilmRoomParam filmRoomParam);
        bool Update(int? Id, FilmRoomParam filmRoomParam);
        bool Delete(int? Id);
        List<FilmRoom> Get();
        FilmRoom Get(int? Id);
    }
}
