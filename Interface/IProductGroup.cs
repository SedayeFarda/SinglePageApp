using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IProductGroup:IDisposable
    {
        void save();
        void update(ProductGroup productGroup);
        void insert(ProductGroup productGroup);
        List<ProductGroup> GetAllProductGroup();

        void delete(int id);
    }
}
