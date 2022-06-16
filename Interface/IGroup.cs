using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp.Interface
{
    interface IGroup:IDisposable
    {
        void save();
        bool update(Group groups);
        bool insert(Group groups);

        bool delete(int id);
        Group GetById(int id);

        List<Group> GetAllGroups();
    }
}
