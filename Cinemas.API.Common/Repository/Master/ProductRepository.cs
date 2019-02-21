using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.DataAccess.Context;

namespace Cinemas.API.Common.Repository.Master
{
    public class ProductRepository : IProductRepository
    {
        MyContext myContext = new MyContext();
        Product product = new Product();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Product getProduct = Get(Id);
            getProduct.IsDelete = true;
            getProduct.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Product> Get()
        {
            var getProduct = myContext.Products.Where(x => x.IsDelete == false).ToList();
            return getProduct;
        }

        public Product Get(int? Id)
        {
            var getProduct = myContext.Products.Find(Id);
            return getProduct;
        }

        public List<Product> GetProduct(int? Id)
        {
            return myContext.Products.Where(x => x.Restaurants.Cinemas.Id == Id && x.IsDelete == false).ToList();
        }

        public List<Product> GetProductByRestaurant(int? Id)
        {
            return myContext.Products.Where(x => x.Restaurants.Id == Id && x.IsDelete == false).ToList();
        }

        public bool Insert(ProductParam productParam)
        {
            var result = 0;
            product.Name = productParam.Name;
            product.Variety = productParam.Variety;
            product.Description = productParam.Description;
            product.Image = productParam.Image;
            product.Price = productParam.Price;
            product.Restaurants = myContext.Restaurants.Find(productParam.Restaurants_Id);
            product.CreateDate = DateTimeOffset.Now.LocalDateTime;
            product.IsDelete = false;
            myContext.Products.Add(product);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, ProductParam productParam)
        {
            var result = 0;
            Product getProduct = Get(Id);
            getProduct.Name = productParam.Name;
            getProduct.Variety = productParam.Variety;
            getProduct.Description = productParam.Description;
            getProduct.Image = productParam.Image;
            getProduct.Price = productParam.Price;
            getProduct.Restaurants = myContext.Restaurants.Find(productParam.Restaurants_Id);
            getProduct.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
