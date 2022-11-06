using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp.Context
{
    public class DbSinglePageContext : DbContext
    {
        public DbSinglePageContext() : base("DbMarket")
        {

        }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<GroupGalleries> GroupGallerys { get; set; }

        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<logo> logos { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProductGroup> ProductsGroups { get; set; }

        public DbSet<PropertyProduct> PropertyProducts { get; set; }
        public DbSet<GalleryProduct> GalleryProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}