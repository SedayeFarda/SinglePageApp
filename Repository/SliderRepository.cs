using SinglePageApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class SliderRepository : ISlider
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void Dispose()
        {
            Dispose();
        }

        public Slider GetById(int id)
        {
           return db.Slider.Find(id);
        }

        public void insert(Slider slider)
        {
            db.Slider.Add(slider);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Slider slider)
        {
            db.Entry(slider).State=EntityState.Modified;
            Save();
        }
    }
}