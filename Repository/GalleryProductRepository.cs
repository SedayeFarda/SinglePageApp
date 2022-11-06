using SinglePageApp.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class GalleryProductRepository : IGalleryProduct
    {
        DbSinglePageContext db;
        public GalleryProductRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
        public bool delete(int id)
        {
            try
            {
                var GalleryProduct = db.GalleryProducts.Find(id);
                db.Entry(GalleryProduct).State = EntityState.Deleted;
                save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<GalleryProduct> GetAllList()
        {
            return db.GalleryProducts.ToList();
        }

        public GalleryProduct GetById(int id)
        {
            return db.GalleryProducts.Find(id);
        }

        public bool insert(GalleryProduct galleryProduct)
        {
            try
            {
                db.GalleryProducts.Add(galleryProduct);
                save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}