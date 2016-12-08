using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Список коплектующих")]
    public class ListOfAccessories
    {
        [Key]
        public int ListOfaccessoriesId { get; set; }

        public Accessories Accessorie { get; set; }

        public Orders Orders { get; set;}
    }
}