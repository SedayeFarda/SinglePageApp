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
            return db.logo.Count();
        }

        public void Dispose()
        {
            Dispose();
        }

        public logo GetById(int id)
        {
            return db.logo.Find(id);
        }

        public void insert(logo logo)
        {
            db.logo.Add(logo);
            Save();
        }

        public List<logo> GetAllLogo()
        {
            return db.logo.ToList();
            
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(logo logo)
        {
            db.Entry(logo).State=EntityState.Modified;
            Save();
        }
    }
}