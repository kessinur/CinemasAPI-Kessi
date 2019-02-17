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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _roomRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Room> Get()
        {
            return _roomRepository.Get();
        }

        public Room Get(int? Id)
        {
            return _roomRepository.Get(Id);
        }

        public bool Insert(RoomParam roomParam)
        {
            _roomRepository.Insert(roomParam);
            return status = true;
        }

        public bool Update(int? Id, RoomParam roomParam)
        {
            _roomRepository.Update(Id, roomParam);
            return status = true;
        }
    }
}
