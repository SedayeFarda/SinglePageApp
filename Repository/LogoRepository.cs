using SinglePageApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class LogoRepository : ILogo
    {
        DbSinglePageContext db = new DbSinglePageContext();

        public int CountLogo()
        {
            return db.logos.Count();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public logo GetById(int id)
        {
            return db.logos.Find(id);
        }

        public void insert(logo logo)
        {
            db.logos.Add(logo);
            Save();
        }

        public List<logo> GetAllLogo()
        {
            return db.logos.ToList();

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(logo logo)
        {
            db.Entry(logo).State = EntityState.Modified;
            Save();
        }
    }
}