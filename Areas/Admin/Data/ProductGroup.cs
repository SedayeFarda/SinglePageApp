using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinglePageApp
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
         [Display(Name = "آیدی گروه")]
        [ForeignKey("Group")]

        public int GroupsId { get; set; }
         [Display(Name = "آیدی کالا")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Product Product { get; set; }
      
    }
}