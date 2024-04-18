﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Models
{
    public class SubCatagory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int CatagoryId { get; set;}
        public Category Category { get; set; }
    }
}
