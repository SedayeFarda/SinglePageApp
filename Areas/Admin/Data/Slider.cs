using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class Slider
    {
        [Key]
        public int id { get; set; }
        public string  ImagePath { get; set; }
    }
}