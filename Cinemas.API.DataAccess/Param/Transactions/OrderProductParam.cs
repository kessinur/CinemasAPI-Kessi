using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param.Transactions
{
    public class OrderProductParam
    {
        public int Quantity { get; set; }
        public int Products_Id { get; set; }
        public int Reservations_Id { get; set; }
    }
}
