using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    class DescriptionRepository : IDescription
    {

        DbSinglePageContext db;
        public DescriptionRepository(DbSinglePageContext _db)
        {
            db = _db;
        }


        public void Delete(int id)
        {
            var description = GetById(id);
            db.Entry(description).State = EntityState.Deleted;
            Save();
        }

        public void Dispose()
        {
            Dispose();
        }

        public List<Description> GetAllList()
        {
            return db.Descriptions.ToList();
        }

        public Description GetById(int id)
        {
            return db.Descriptions.Find(id);
        }

        public void insert(Description description)
        {
            db.Descriptions.Add(description);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Description description)
        {
            db.Entry(description).State = EntityState.Modified;
            Save();
        }
    }
}