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
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
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
                status = _theaterRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Theater> Get()
        {
            return _theaterRepository.Get();
        }

        public Theater Get(int? Id)
        {
            var getTheaterId = _theaterRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getTheaterId;
        }

        public bool Insert(TheaterParam theaterParam)
        {
            if (theaterParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _theaterRepository.Insert(theaterParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, TheaterParam theaterParam)
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
                status = _theaterRepository.Update(Id, theaterParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
