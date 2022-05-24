using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp
{
  public  interface IDescription:IDisposable
    {
        List<Description> GetAllList();
        void insert(Description description);
        void Delete(int id);

        Description GetById(int id);
        void Update(Description description);
        void Save();
    }
}
