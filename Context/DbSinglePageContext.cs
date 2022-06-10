using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class DbSinglePageContext : DbContext
    {
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GroupGallery> GroupGallery { get; set; }

        public DbSet<Description> Description { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<logo> logo { get; set; }
        public DbSet<Slider> Slider { get; set; }

        public DbSet<Product> Product { get; set; }
    }
    }