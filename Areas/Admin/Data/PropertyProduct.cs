using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class PropertyProduct
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [ForeignKey("ProductId")]

        public virtual Product Product { get; set; }
    }
}