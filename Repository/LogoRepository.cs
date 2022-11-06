using SinglePageApp.Context;
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
        DbSinglePageContext _db;
        public LogoRepository(DbSinglePageContext db)
        {
            _db = db;
        }

        public int CountLogo()
        {
            return _db.logos.Count();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public logo GetById(int id)
        {
            return _db.logos.Find(id);
        }

        public void insert(logo logo)
        {
            _db.logos.Add(logo);
            Save();
        }

        public List<logo> GetAllLogo()
        {
            return _db.logos.ToList();

        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(logo logo)
        {
            _db.Entry(logo).State = EntityState.Modified;
            Save();
        }
    }
}