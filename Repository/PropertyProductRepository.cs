using SinglePageApp.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class PropertyProductRepository : IPropertyProduct
    {
        DbSinglePageContext db;
        public PropertyProductRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
        public bool delete(int id)
        {
            try
            {
                var propertyProduct = db.PropertyProducts.Find(id);
                db.Entry(propertyProduct).State = EntityState.Deleted;
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

        public List<PropertyProduct> GetAllList()
        {
            return db.PropertyProducts.ToList();
        }

        public PropertyProduct GetById(int id)
        {
            return db.PropertyProducts.Find(id);
        }

        public bool insert(PropertyProduct propertyProduct)
        {
            try {

                db.PropertyProducts.Add(propertyProduct);
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

        public bool update(PropertyProduct propertyProduct)
        {
            try
            {
                db.Entry(propertyProduct).State = EntityState.Modified;
                save();
                return true;

            }
            catch
            {
                return false;

            }
        }
    }
}