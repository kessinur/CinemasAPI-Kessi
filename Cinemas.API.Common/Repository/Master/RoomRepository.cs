using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.DataAccess.Context;

namespace Cinemas.API.Common.Repository.Master
{
    public class RoomRepository : IRoomRepository
    {
        MyContext myContext = new MyContext();
        Room room = new Room();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Room getRoom = Get(Id);
            getRoom.IsDelete = true;
            getRoom.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Room> Get()
        {
            var getRoom = myContext.Rooms.Where(x => x.IsDelete == false).ToList();
            return getRoom;
        }

        public Room Get(int? Id)
        {
            var getRoom = myContext.Rooms.Find(Id);
            return getRoom;
        }

        public bool Insert(RoomParam roomParam)
        {
            var result = 0;
            room.Name = roomParam.Name;
            room.Seat = roomParam.Seat;
            room.Cinemas = myContext.Cinemas.Find(roomParam.Cinemas_Id);
            room.CreateDate = DateTimeOffset.Now.LocalDateTime;
            room.IsDelete = false;
            myContext.Rooms.Add(room);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, RoomParam roomParam)
        {
            var result = 0;
            Room getRoom = Get(Id);
            getRoom.Name = roomParam.Name;
            getRoom.Seat = roomParam.Seat;
            getRoom.Cinemas = myContext.Cinemas.Find(roomParam.Cinemas_Id);
            getRoom.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
