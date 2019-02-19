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
    public class CategoryRepository : ICategoryRepository
    {
        MyContext myContext = new MyContext();
        Category category = new Category();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Category getCategory = Get(Id);
            getCategory.IsDelete = true;
            getCategory.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Category> Get()
        {
            var getCategory = myContext.Categories.Where(x => x.IsDelete == false).ToList();
            return getCategory;
        }

        public Category Get(int? Id)
        {
            var getCategory = myContext.Categories.Find(Id);
            return getCategory;
        }

        public bool Insert(CategoryParam categoryParam)
        {
            var result = 0;
            category.Name = categoryParam.Name;
            category.CreateDate = DateTimeOffset.Now.LocalDateTime;
            category.IsDelete = false;
            myContext.Categories.Add(category);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, CategoryParam categoryParam)
        {
            var result = 0;
            Category getCategory = Get(Id);
            getCategory.Name = categoryParam.Name;
            getCategory.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
