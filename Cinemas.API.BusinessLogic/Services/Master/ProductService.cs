using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _productRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product Get(int? Id)
        {
            return _productRepository.Get(Id);
        }

        public bool Insert(ProductParam productParam)
        {
            _productRepository.Insert(productParam);
            return status = true;
        }

        public bool Update(int? Id, ProductParam productParam)
        {
            _productRepository.Update(Id, productParam);
            return status = true;
        }

        public List<Product> GetProduct(int? Id)
        {
            return _productRepository.GetProduct(Id);
        }

        public List<Product> GetProductByRestaurant(int? Id)
        {
            return _productRepository.GetProductByRestaurant(Id);
        }
    }
}
