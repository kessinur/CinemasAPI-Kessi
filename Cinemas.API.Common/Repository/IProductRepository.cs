using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Common.Repository
{
    public interface IProductRepository
    {
        bool Insert(ProductParam productParam);
        bool Update(int? Id, ProductParam productParam);
        bool Delete(int? Id);
        List<Product> Get();
        Product Get(int? Id);
    }
}
