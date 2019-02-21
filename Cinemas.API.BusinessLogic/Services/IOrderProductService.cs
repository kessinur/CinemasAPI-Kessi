using Cinemas.API.DataAccess.Model.Transactions;
using Cinemas.API.DataAccess.Param.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface IOrderProductService
    {
        bool Insert(OrderProductParam orderproductParam);
        bool Delete(int? Id);
        List<OrderProduct> Get();
        OrderProduct Get(int? Id);
    }
}
