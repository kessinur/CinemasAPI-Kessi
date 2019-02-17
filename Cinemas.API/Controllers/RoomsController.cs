using Cinemas.API.BusinessLogic.Services;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cinemas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoomsController : ApiController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return _roomService.Get();
        }

        // GET: api/Rooms/5
        public Room Get(int id)
        {
            return _roomService.Get(id);
        }

        // POST: api/Rooms
        public void Post(RoomParam roomParam)
        {
            _roomService.Insert(roomParam);
        }

        // PUT: api/Rooms/5
        public void Put(int id, RoomParam roomParam)
        {
            _roomService.Update(id, roomParam);
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
            _roomService.Delete(id);
        }
    }
}
