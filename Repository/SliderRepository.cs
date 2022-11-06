using SinglePageApp.Context;
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
        DbSinglePageContext _db;
        public SliderRepository(DbSinglePageContext db)
        {
            _db = db;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public Slider GetById(int id)
        {
            return _db.Sliders.Find(id);
        }

        public void insert(Slider slider)
        {
            _db.Sliders.Add(slider);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Slider slider)
        {
            _db.Entry(slider).State = EntityState.Modified;
            Save();
        }
    }
}