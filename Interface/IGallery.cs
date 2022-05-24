using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IGallery
    {
        List<Gallery> GetAllList();

        void save();
        void insert(Gallery gallery);
        Gallery GetById(int id);
        void update(Gallery gallery);

        void delete(int id);
    }
}
