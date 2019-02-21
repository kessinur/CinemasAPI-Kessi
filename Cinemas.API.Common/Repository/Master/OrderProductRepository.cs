using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model.Transactions;
using Cinemas.API.DataAccess.Param.Transactions;
using Cinemas.API.DataAccess.Context;

namespace Cinemas.API.Common.Repository.Master
{
    public class OrderProductRepository : IOrderProductRepository
    {
        MyContext myContext = new MyContext();
        OrderProduct orderproduct = new OrderProduct();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            OrderProduct getOrderProduct = Get(Id);
            getOrderProduct.IsDelete = true;
            getOrderProduct.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<OrderProduct> Get()
        {
            var getOrderProduct = myContext.OrderProducts.Where(x => x.IsDelete == false).ToList();
            return getOrderProduct;
        }

        public OrderProduct Get(int? Id)
        {
            var getOrderProduct = myContext.OrderProducts.Find(Id);
            return getOrderProduct;
        }

        public bool Insert(OrderProductParam orderproductParam)
        {
            var result = 0;
            orderproduct.Quantity = orderproductParam.Quantity;
            orderproduct.Products = myContext.Products.Find(orderproductParam.Products_Id);
            orderproduct.Reservations = myContext.Reservations.Find(orderproductParam.Reservations_Id);
            orderproduct.CreateDate = DateTimeOffset.Now.LocalDateTime;
            orderproduct.IsDelete = false;
            myContext.OrderProducts.Add(orderproduct);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
