using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Заказчики")]
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name_Surname { get; set; }

        public string Adress { get; set; }

        public string Telephone { get; set; }

        public bool Discount { get; set; }

        public int Value { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}