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
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        public IEnumerable<Category> Get()
        {
            return _categoryService.Get();
        }

        // GET: api/Categories/5
        public Category Get(int id)
        {
            return _categoryService.Get(id);
        }

        // POST: api/Categories
        public void Post(CategoryParam categoryParam)
        {
            _categoryService.Insert(categoryParam);
        }

        // PUT: api/Categories/5
        public void Put(int id, CategoryParam categoryParam)
        {
            _categoryService.Update(id, categoryParam);
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
    }
}
