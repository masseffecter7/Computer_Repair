﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Repair.Models
{
    [Table("Услуги")]
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }

        public float Price { get; set; }

        public List<Orders> Orderss { get; set; }
    }
}