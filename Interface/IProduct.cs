using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
