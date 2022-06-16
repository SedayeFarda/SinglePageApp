using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class ProductGroupRepository : IProductGroup
    {
        DbSinglePageContext db;
        public ProductGroupRepository(DbSinglePageContext _db)
        {
            db = _db;
        }

        public void delete(int id)
        {
            
            Product product = db.Products.Find(id);
           

            if (product.ProductGroup.Any())
            {

                db.ProductsGroups.RemoveRange(product.ProductGroup);
                save();
            }


        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<ProductGroup> GetAllProductGroup()
        {
            return db.ProductsGroups.ToList();
        }

        public void insert(ProductGroup productGroup)
        {
            db.ProductsGroups.Add(productGroup);
            save();
        }

        public void save()
        {
            try
            {

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public void update(ProductGroup productGroup)
        {
            db.Entry(productGroup).State = EntityState.Modified;
            save();
        }
    }
}