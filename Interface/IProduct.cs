using System;
using System.Collections.Generic;

namespace SinglePageApp.Interface
{
    interface IProduct:IDisposable
    {
        void insert(Product product);
        bool update(Product product);
        bool delete(int id);

        void save();

        Product GetById(int id);

        List<Product> ListProduct();
    }
}
