﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinemas.API.DataAccess.Model;
using Cinemas.API.DataAccess.Param;
using Cinemas.API.Common.Repository;

namespace Cinemas.API.BusinessLogic.Services.Master
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionRepository _religionRepository;

        public ReligionService(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
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
                status = _religionRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Religion> Get()
        {
            return _religionRepository.Get();
        }

        public Religion Get(int? Id)
        {
            var getReligionId = _religionRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getReligionId;
        }

        public bool Insert(ReligionParam religionParam)
        {
            if (religionParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _religionRepository.Insert(religionParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, ReligionParam religionParam)
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
                status = _religionRepository.Update(Id, religionParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
