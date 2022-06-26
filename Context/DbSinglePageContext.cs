using System.Data.Entity;

namespace SinglePageApp
{
    public class DbSinglePageContext : DbContext
    {
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<GroupGallery> GroupGallerys { get; set; }

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