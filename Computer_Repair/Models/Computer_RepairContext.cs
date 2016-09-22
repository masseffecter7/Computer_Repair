﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computer_Repair.Models
{
    public class Computer_RepairContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Computer_RepairContext() : base("name=Computer_RepairContext")
        {
        }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Accessorie> Accessories { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.KindsOfAccessories> KindsOfAccessories { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Customers> Customers { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Workers> Workers { get; set; }

        public System.Data.Entity.DbSet<Computer_Repair.Models.Services> Services { get; set; }
    }
}
