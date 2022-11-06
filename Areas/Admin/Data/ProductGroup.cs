using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinglePageApp
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
         [Display(Name = "آیدی گروه")]
       

        public int GroupsId { get; set; }
        [ForeignKey("GroupsId")]
        public virtual Group Group { get; set; }
        [Display(Name = "آیدی کالا")]
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

       
       
      
    }
}