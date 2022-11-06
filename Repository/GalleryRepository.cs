using SinglePageApp.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SinglePageApp.Repository
{
    public class GalleryRepository : IGallery
    {
        DbSinglePageContext db;
        public GalleryRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
        public void delete(int id)
        {
            var gallery = GetById(id);
            db.Entry(gallery).State = EntityState.Deleted;
            save();
        }

        public List<Gallery> GetAllList()
        {
            return db.Gallerys.ToList();
        }

        public Gallery GetById(int id)
        {
            return db.Gallerys.Find(id);
        }

        public void insert(Gallery gallery)
        {
            db.Gallerys.Add(gallery);
            save();
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void update(Gallery gallery)
        {

            var item = GetById(gallery.id);
            item.ImagePath = gallery.ImagePath;
            item.GroupGallery_id = gallery.GroupGallery_id;
            save();
        }
    }
}