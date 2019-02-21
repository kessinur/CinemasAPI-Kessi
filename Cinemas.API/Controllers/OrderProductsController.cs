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
    public class OrderProductsController : ApiController
    {
        private readonly IOrderProductService _orderproductService;

        public OrderProductsController(IOrderProductService orderproductService)
        {
            _orderproductService = orderproductService;
        }
        // GET: api/OrderProducts
        public IEnumerable<OrderProduct> Get()
        {
            return _orderproductService.Get();
        }

        // GET: api/OrderProducts/5
        public OrderProduct Get(int id)
        {
            return _orderproductService.Get(id);
        }

        // POST: api/OrderProducts
        public void Post(OrderProductParam orderproductParam)
        {
            _orderproductService.Insert(orderproductParam);
        }

        // PUT: api/OrderProducts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderProducts/5
        public void Delete(int id)
        {
            _orderproductService.Delete(id);
        }
    }
}
