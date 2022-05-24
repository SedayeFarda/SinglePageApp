using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class ContactRepository : IContact
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void Delete(int id)
        {
            var item = db.Contact.Find(id);
            db.Contact.Remove(item);
            Save();
        }

        public void Dispose()
        {
            Dispose();
        }

        public List<Contact> GetAllList()
        {
            return db.Contact.ToList();
        }

        public Contact GetById(int id)
        {
            return db.Contact.Find(id);
        }

        public void insert(Contact contact)
        {
            db.Contact.Add(contact);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Contact contact)
        {
            db.Entry(contact).State=EntityState.Modified;
            Save();
        }
    }
}