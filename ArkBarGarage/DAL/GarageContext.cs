using System;
using System.Collections.Generic;
using System.Data.Entity;
using ClassicGarageArkBar.Models;
using System.Linq;
using System.Web;

namespace ClassicGarageArkBar.DAL
{
    public class GarageContext : DbContext
    {
       // public GarageContext() : base("name=ClassicGarageArkBarConnection") { }

        public DbSet<CarsModels> Car { get; set; }

        public DbSet<OwnerModels> Owner { get; set; }

        public System.Data.Entity.DbSet<ClassicGarageArkBar.Models.AdModel> AdModels { get; set; }

        public System.Data.Entity.DbSet<ClassicGarageArkBar.Models.PartsModels> PartsModels { get; set; }

        public System.Data.Entity.DbSet<ClassicGarageArkBar.Models.RepairsModels> RepairsModels { get; set; }
    }
}