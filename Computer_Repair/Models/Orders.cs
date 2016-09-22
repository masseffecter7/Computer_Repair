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
        
        public List<string> AccessorieId { get; set; } //список комплектующих (м->м)
        
        public decimal Payment { get; set; }
        
        public bool MarkOfPayment { get; set; }
        
        public bool MarkOfComplection { get; set; }
        
        public decimal TotalCost { get; set; }
        
        public string WarrantyPeriod { get; set; }

        public List<string> ServiceId { get; set; } //список услуг (м->м)

        public int WorkerId { get; set; }       //др

        public Workers Workers { get; set; } //для workerid
    }
}