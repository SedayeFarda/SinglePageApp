using SinglePageApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class ProductRepository : IProduct
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public bool delete(int id)
        {
            try
            {
                Product product = GetById(id);
                db.Entry(product).State = EntityState.Deleted;
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
            Dispose();
        }

        public Product GetById(int id)
        {
           Product product= db.Product.Find(id);
            return product;
        }

        public void insert(Product product)
        {
            db.Product.Add(product);
            save();
        }

        public List<Product> ListProduct()
        {
            return db.Product.ToList();
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

        public bool update(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
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