using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Виды комплектующих")]
    public class KindsOfAccessories
    {
        [Key]
        public int KindId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Accessorie> Accessories { get; set; }
    }
}