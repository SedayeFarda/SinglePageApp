using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SinglePageApp.Repository
{
    public class GalleryRepository : IGallery
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void delete(int id)
        {
            var gallery = GetById(id);
            db.Entry(gallery).State = EntityState.Deleted;
            save();
        }

        public List<Gallery> GetAllList()
        {
            return db.Gallery.ToList();
        }

        public Gallery GetById(int id)
        {
            return db.Gallery.Find(id);
        }

        public void insert(Gallery gallery)
        {
            db.Gallery.Add(gallery);
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