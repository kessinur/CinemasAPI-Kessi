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
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return _productService.Get();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return _productService.Get(id);
        }

        // POST: api/Products
        public void Post(ProductParam productParam)
        {
            _productService.Insert(productParam);
        }

        // PUT: api/Products/5
        public void Put(int id, ProductParam productParam)
        {
            _productService.Update(id, productParam);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            _productService.Delete(id);
        }

        public IEnumerable<Product> GetProduct(int RId)
        {
            return _productService.GetProduct(RId);
        }

        public IEnumerable<Product> GetProductByRestaurant(int RId)
        {
            return _productService.GetProductByRestaurant(RId);
        }
    }
}
