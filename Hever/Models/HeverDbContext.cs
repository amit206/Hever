using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hever.Models
{
    public class HeverDbContext: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}