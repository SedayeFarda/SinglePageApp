using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageApp.Interface
{
   public interface ISlider:IDisposable
    {
        void insert(Slider slider);
        Slider GetById(int id);
        void Update(Slider slider);
        void Save();
    }
}
