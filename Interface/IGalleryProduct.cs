using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IGalleryProduct:IDisposable
    {
        void save();
        bool insert(GalleryProduct galleryProduct);
        bool delete(int id);
        GalleryProduct GetById(int id);
        List<GalleryProduct> GetAllList();
    }
}
