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
    public class FilmRoomRepository : IFilmRoomRepository
    {
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            FilmRoom filmRoom = Get(Id);
            filmRoom.IsDelete = true;
            filmRoom.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<FilmRoom> Get()
        {
            var get = myContext.FilmRooms.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public FilmRoom Get(int? Id)
        {
            FilmRoom filmRoom = myContext.FilmRooms.Where(x => x.Id == Id).SingleOrDefault();
            return filmRoom;
        }

        public bool Insert(FilmRoomParam filmRoomParam)
        {
            var result = 0;
            var filmRoom = new FilmRoom();
            filmRoom.ShowDate = filmRoomParam.ShowDate;
            filmRoom.Hour = filmRoomParam.Hour;
            filmRoom.Price = filmRoomParam.Price;
            filmRoom.Films = myContext.Films.Find(filmRoomParam.Films_Id);
            filmRoom.Rooms = myContext.Rooms.Find(filmRoomParam.Rooms_Id);
            myContext.FilmRooms.Add(filmRoom);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int? Id, FilmRoomParam filmRoomParam)
        {
            var result = 0;
            var get = Get(Id);
            get.ShowDate = filmRoomParam.ShowDate;
            get.Hour = filmRoomParam.Hour;
            get.Price = filmRoomParam.Price;
            get.Films = myContext.Films.Find(filmRoomParam.Films_Id);
            get.Rooms = myContext.Rooms.Find(filmRoomParam.Rooms_Id);
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
