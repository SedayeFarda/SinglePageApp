using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class logo
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="نام کامل")]
        [Required(ErrorMessage ="لطفا{0}را وارد کنید")]
        [MaxLength(length:50)]
        public string FullName { get; set; }
        public string ImagePath { get; set; }
    }
}