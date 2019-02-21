using Cinemas.API.BusinessLogic.Services;
using Cinemas.API.DataAccess.Model.Transactions;
using Cinemas.API.DataAccess.Param.Transactions;
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
    public class BuyTicketsController : ApiController
    {
        private readonly IBuyTicketService _buyticketService;

        public BuyTicketsController(IBuyTicketService buyticketService)
        {
            _buyticketService = buyticketService;
        }
        // GET: api/BuyTickets
        public IEnumerable<BuyTicket> Get()
        {
            return _buyticketService.Get();
        }

        // GET: api/BuyTickets/5
        public BuyTicket Get(int id)
        {
            return _buyticketService.Get(id);
        }

        // POST: api/BuyTickets
        public void Post(BuyTicketParam buyticketParam)
        {
            _buyticketService.Insert(buyticketParam);
        }

        // PUT: api/BuyTickets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BuyTickets/5
        public void Delete(int id)
        {
            _buyticketService.Delete(id);
        }
    }
}
