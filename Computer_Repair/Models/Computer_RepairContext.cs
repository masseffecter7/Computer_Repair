using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computer_Repair.Models
{
    public class Computer_RepairContext : DbContext
    {    
        public Computer_RepairContext() : base("name=Computer_RepairContext")
        {
        }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Accessories> Accessories { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.KindsOfAccessories> KindsOfAccessories { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Customers> Customers { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Workers> Workers { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Services> Services { get; set; }
    }
}
