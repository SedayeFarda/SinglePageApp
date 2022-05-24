using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp.Interface
{
   public interface ILogo:IDisposable
    {
        
        void insert(logo logo);        
        logo GetById(int id);
        void Update(logo logo);
        void Save();

        int CountLogo();
        List<logo> GetAllLogo();
    }
}
