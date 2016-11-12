using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("KindsOfAccessories")]
    public class KindsOfAccessories
    {
        [Key]
        public int KindId { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Accessorie> Accessories { get; set; }
    }
}