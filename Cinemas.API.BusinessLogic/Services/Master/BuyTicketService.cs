using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model.Transactions;
using Cinemas.API.DataAccess.Param.Transactions;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class BuyTicketService : IBuyTicketService
    {
        private readonly IBuyTicketRepository _buyticketRepository;

        public BuyTicketService(IBuyTicketRepository buyticketRepository)
        {
            _buyticketRepository = buyticketRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _buyticketRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<BuyTicket> Get()
        {
            return _buyticketRepository.Get();
        }

        public BuyTicket Get(int? Id)
        {
            return _buyticketRepository.Get(Id);
        }

        public bool Insert(BuyTicketParam buyticketParam)
        {
            _buyticketRepository.Insert(buyticketParam);
            return status = true;
        }
    }
}
