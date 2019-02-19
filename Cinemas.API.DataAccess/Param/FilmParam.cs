using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Param
{
    public class FilmParam
    {
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Poster { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public int Categories_Id { get; set; }
    }
}
