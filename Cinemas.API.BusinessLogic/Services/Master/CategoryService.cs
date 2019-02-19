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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoriRepository)
        {
            _categoryRepository = categoriRepository;
        }

        bool status = false;
        public bool Delete(int? Id)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _categoryRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Category> Get()
        {
            return _categoryRepository.Get();
        }

        public Category Get(int? Id)
        {
            var getCategoryId = _categoryRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getCategoryId;
        }

        public bool Insert(CategoryParam categoryParam)
        {
            if (categoryParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _categoryRepository.Insert(categoryParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, CategoryParam categoryParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _categoryRepository.Update(Id, categoryParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
