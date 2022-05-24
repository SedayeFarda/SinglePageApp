using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
    interface IGroupGallery:IDisposable
    {
        List<GroupGallery> GetAllList();

        void save();
        void insert(GroupGallery gallery);
        GroupGallery GetById(int id);
        void update(GroupGallery gallery);

        void delete(int id);
    }
}
