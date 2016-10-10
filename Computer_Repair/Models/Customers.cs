using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Computer_Repair.Models
{
    [Table("Заказчики")]
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name_Surname { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Telephone { get; set; }

        public bool Discount { get; set; }

        //не смотря ни на что требует заполнить!!! БРЕД! ИСПРАВИТЬ...! 
        //[DisplayFormat(ConvertEmptyStringToNull = true)]
        [DefaultValue("0")]
        public int Value { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}