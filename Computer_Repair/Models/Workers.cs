using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Сотрудники")]
    public class Workers
    {
        [Key]
        public int WorkerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}