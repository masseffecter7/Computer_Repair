using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Комплектующее")]
    public class Accessorie
    {
        [Key]
        public int AccessorieId { get; set; }

        public int KindId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public KindsOfAccessories KindsOfAccessories { get; set; }
    }
}