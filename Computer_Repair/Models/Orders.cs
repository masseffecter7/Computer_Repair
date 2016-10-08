using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Заказы")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateOfOrder { get; set; }
        
        public DateTime DateOfComplection { get; set; }
        
        public int CustomerId { get; set; } //др

        public Customers Customers { get; set; } //для customerid

        public string ListOfAccessories { get; set; }
        public Accessorie Accessorie { get; set; }       //список комплектующих (м->м)

        public int Payment { get; set; }
        
        public bool MarkOfPayment { get; set; }
        
        public bool MarkOfComplection { get; set; }
        
        public int TotalCost { get; set; }
        
        public string WarrantyPeriod { get; set; }

        public string ListOfServices { get; set; }
        public Services Services { get; set; }           //список услуг (м->м) 

        public int WorkerId { get; set; }       //др

        public Workers Workers { get; set; } //для workerid




        /*public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public ICollection<Player> Players { get; set; }
            public Team()
            {
                Players = new List<Player>();
            }
        }
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public int Age { get; set; }

            public ICollection<Team> Teams { get; set; }
            public Player()
            {
                Teams = new List<Team>();
            }
        }*/




    }
}