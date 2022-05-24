using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        [MaxLength(length:50)]
        [Display(Name ="نام کاربر")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string NameUser { get; set; }
        
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="لطفا یک ایمیل معتبر وارد کنید")]
        public string EmailUser { get; set; }
        [MaxLength(length: 100)]
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Subject { get; set; }
        
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Message { get; set; }
    }
}