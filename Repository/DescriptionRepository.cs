using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class DescriptionRepository : IDescription
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void Delete(int id)
        {
            var description=GetById(id);
            db.Entry(description).State = EntityState.Deleted;
            Save();
        }

        public void Dispose()
        {
            Dispose();
        }

        public List<Description> GetAllList()
        {
            return db.Description.ToList();
        }

        public Description GetById(int id)
        {
            return db.Description.Find(id);
        }

        public void insert(Description description)
        {
            db.Description.Add(description);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Description description)
        {
            db.Entry(description).State = EntityState.Modified ;
            Save();
        }
    }
}