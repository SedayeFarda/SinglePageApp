using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IGroupGallery:IDisposable
    {
        List<GroupGalleries> GetAllList();

        void save();
        void insert(GroupGalleries gallery);
        GroupGalleries GetById(int id);
        void update(GroupGalleries gallery);

        void delete(int id);
    }
}
