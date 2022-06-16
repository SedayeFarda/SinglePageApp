using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageApp
{
    public class Product
    {
        
        [Key]
        public int ProductId { get; set; }
         [Display(Name = "قیمت")]
          [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Title { get; set; }
        
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]     
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Discryption { get; set; }
        [Display(Name = "تگ ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Tags { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Linq { get; set; }
        [Display(Name = "عکس")]
      [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        public string ImgName { get; set; }
        [NotMapped]
        [Display(Name = "فایل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public HttpPostedFileBase UploadFile { get; set; }

        public virtual ICollection<ProductGroup> ProductGroup { get; set; }
       
    }
}