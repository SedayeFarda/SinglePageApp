using SinglePageApp.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace SinglePageApp
{
    public class ProductRepository : IProduct
    {
        DbSinglePageContext db;
        public ProductRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
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
            db.Dispose();
        }

        public Product GetById(int id)
        {
            Product product = db.Products.Find(id);
            return product;
        }

        public void insert(Product product)
        {
            db.Products.Add(product);
            save();
        }

        public List<Product> ListProduct()
        {
            return db.Products.Include(x=>x.GalleryProduct).Include(x=>x.PropertyProduct).ToList();
        }

        public void save()
        {
            

                db.SaveChanges();
           
          

        }

        public bool update(Product _product)
        {
            var product = db.Products.Find(_product.ProductId);
            product.Discryption = _product.Discryption;
            product.ImgName = _product.ImgName;
            product.Linq = _product.Linq;
            product.Price = _product.Price;
            product.Tags = _product.Tags;
            product.Title = _product.Title;
           
            save();
            return true;

        }
    }
}