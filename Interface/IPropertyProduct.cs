using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IPropertyProduct:IDisposable
    {
        void save();
        bool update(PropertyProduct propertyProduct);
        bool insert(PropertyProduct propertyProduct);
        bool delete(int id);
        List<PropertyProduct> GetAllList();
        PropertyProduct GetById(int id);
    }
}
