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
        
        public DateTime DateOfOrder { get; set; }
        
        public DateTime DateOfComplection { get; set; }
        
        public int CustomerId { get; set; } //др

        public Customers Customers { get; set; } //для customerid
      
        public List<Accessorie> Accessories { get; set; }       //список комплектующих (м->м)
        public List<string> AccessorieId { get; set; }

        public decimal Payment { get; set; }
        
        public bool MarkOfPayment { get; set; }
        
        public bool MarkOfComplection { get; set; }
        
        public decimal TotalCost { get; set; }
        
        public string WarrantyPeriod { get; set; }

        public List<Services> Servicess { get; set; }           //список услуг (м->м)
        public List<string> SeviceId { get; set; }

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