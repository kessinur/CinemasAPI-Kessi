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
    public class FilmRepository : IFilmRepository
    {

        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Film film = Get(Id);
            film.IsDelete = true;
            film.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Film> Get()
        {
            var get = myContext.Films.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Film Get(int? Id)
        {
            Film film = myContext.Films.Where(x => x.Id == Id).SingleOrDefault();
            return film;
        }

        public bool Insert(FilmParam filmParam)
        {
            var result = 0;
            var film = new Film();
            film.Categories = myContext.Categories.Find(filmParam.Categories_Id);
            film.Title = filmParam.Title;
            film.Rating = filmParam.Rating;
            film.Synopsis = filmParam.Synopsis;
            film.Description = filmParam.Description;
            film.Duration = filmParam.Duration;
            film.Status = filmParam.Status;
            film.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Films.Add(film);
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

        public bool Update(int? Id, FilmParam filmParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Categories = myContext.Categories.Find(filmParam.Categories_Id);
            get.Title = filmParam.Title;
            get.Rating = filmParam.Rating;
            get.Synopsis = filmParam.Synopsis;
            get.Description = filmParam.Description;
            get.Duration = filmParam.Duration;
            get.Status = filmParam.Status;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
    }
}
