using Cinemas.API.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext") { }
        public DbSet<Regency> Regencies { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SubDistrict> SubDistricts { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
