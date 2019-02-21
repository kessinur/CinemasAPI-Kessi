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
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderproductRepository;

        public OrderProductService(IOrderProductRepository orderproductRepository)
        {
            _orderproductRepository = orderproductRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _orderproductRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<OrderProduct> Get()
        {
            return _orderproductRepository.Get();
        }

        public OrderProduct Get(int? Id)
        {
            return _orderproductRepository.Get(Id);
        }

        public bool Insert(OrderProductParam orderproductParam)
        {
            _orderproductRepository.Insert(orderproductParam);
            return status = true;
        }
    }
}
