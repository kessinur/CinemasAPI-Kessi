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
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
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
                status = _filmRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Film> Get()
        {
            return _filmRepository.Get();
        }

        public Film Get(int? Id)
        {
            var getFilmId = _filmRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getFilmId;
        }

        public bool Insert(FilmParam filmParam)
        {
            if (filmParam == null)
            {
                Console.WriteLine("Insert Value");
                Console.Read();
            }
            else
            {
                status = _filmRepository.Insert(filmParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, FilmParam filmParam)
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
                status = _filmRepository.Update(Id, filmParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
