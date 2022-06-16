using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
         [Display(Name = "نام گروه")]
          [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Name { get; set; }
         [Display(Name = "زیر گروه")]
         [ForeignKey("Group1")]
        public int? Parent_id { get; set; }


       
        public virtual Group Group1 { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<ProductGroup> ProductGroups { get; set; }

      
    }
}