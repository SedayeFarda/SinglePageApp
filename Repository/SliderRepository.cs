using SinglePageApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class SliderRepository:ISlider
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void Dispose()
        {
            db.Dispose();
        }

        public Slider GetById(int id)
        {
            return db.Sliders.Find(id);
        }

        public void insert(Slider slider)
        {
            db.Sliders.Add(slider);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Slider slider)
        {
            db.Entry(slider).State = EntityState.Modified;
            Save();
        }
    }
}