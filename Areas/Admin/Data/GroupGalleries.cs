using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class GroupGalleries
    {
        [Key]
        public int GroupGallery_Id { get; set; }
        [Display(Name ="نام گروه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(length: 50)]
        public string Name { get; set; }

        public virtual ICollection<Gallery> Gallery { get; set; }
    }
}