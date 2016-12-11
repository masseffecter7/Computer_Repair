using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Accessories")]
    public class Accessories
    {
        [Key]
        public int AccessorieId { get; set; }

        public int KindId { get; set; }
        public KindsOfAccessories KindsOfAccessories { get; set; }

        [Required]
        public string AccessorieName { get; set; }

        [Required]
        public string Firm { get; set; }

        [Required]
        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Characteristics { get; set; }

        public string Guarantee { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}