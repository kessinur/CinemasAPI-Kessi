using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.BusinessLogic.Services
{
    public interface ICategoryService
    {
        bool Insert(CategoryParam categoryParam);
        bool Update(int? Id, CategoryParam categoryParam);
        bool Delete(int? Id);
        List<Category> Get();
        Category Get(int? Id);
    }
}
