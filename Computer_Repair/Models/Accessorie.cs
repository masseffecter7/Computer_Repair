using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Комплектующие")]
    public class Accessorie
    {
        [Key]
        public int AccessorieId { get; set; }

        public int KindId { get; set; }

        public string AccessorieName { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public KindsOfAccessories KindsOfAccessories { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}