using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfOrder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfCompletion { get; set; }

        [Required]
        public int CustomerId { get; set; } 

        public Customers Customers { get; set; } 

        [Required]
        public string ListOfAccessories { get; set; }
        public Accessorie Accessorie { get; set; }   

        [Required]
        public int Prepaid { get; set; }

        public bool Submitted { get; set; }
        
        public bool Completed { get; set; }

        [Required]
        public int TotalCost { get; set; }
        
        public string Guarantee { get; set; }

        [Required]
        public string ListOfServices { get; set; }
        public Services Services { get; set; }      

        [Required]
        public int WorkerId { get; set; }     

        public Workers Workers { get; set; }
    }
}