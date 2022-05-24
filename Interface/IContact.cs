using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
   public interface IContact:IDisposable
    {
        List<Contact> GetAllList();
        void insert(Contact contact);
        void Delete(int id);

        Contact GetById(int id);
        void Update(Contact contact);
        void Save();
    }
}
