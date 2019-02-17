using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IRoomService
    {
        bool Insert(RoomParam roomParam);
        bool Update(int? Id, RoomParam roomParam);
        bool Delete(int? Id);
        List<Room> Get();
        Room Get(int? Id);
    }
}
