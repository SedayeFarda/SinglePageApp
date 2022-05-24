using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SinglePageApp
{
    public class Gallery
    {
       
        [Key]
        public int id { get; set; }
        [Display(Name ="تصویر")]
        [Required(ErrorMessage ="لطفا{0} را  وارد کنید")]
        [MaxLength(length: 50)]
        public string ImagePath { get; set; }
        [Display(Name = "گروه")]
        [Required(ErrorMessage = "لطفا{0} را  وارد کنید")]
        [ForeignKey("GroupGallery")]
        public int GroupGallery_id { get; set; }
        [Display(Name ="برچسب ها")]

        [Required(ErrorMessage ="لطفا {0}را وارد کنید")]
        public string Tags { get; set; }

        [NotMapped]

        [Display(Name = "فایل")]
        [Required(ErrorMessage = "لطفا{0} را  وارد کنید")]
        public HttpPostedFileBase UploadFile { get; set; }

        public virtual GroupGallery GroupGallery { get; set; }

     
    }
}