using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}