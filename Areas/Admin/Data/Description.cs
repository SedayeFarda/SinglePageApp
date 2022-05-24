using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class Description
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(length:50)]
        public string Title { get; set; }
        [Display(Name ="توضیحات")]
        [Required(ErrorMessage ="لطفا{0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [MaxLength(length:50)]
        public string ImagePath { get; set; }

        [Display(Name = "برچسب ها")]

        [Required(ErrorMessage = "لطفا {0}را وارد کنید")]
        public string Tags { get; set; }

    }
}