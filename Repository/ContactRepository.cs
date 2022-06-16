using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class ContactRepository:IContact
    {
        DbSinglePageContext db = new DbSinglePageContext();
        public void Delete(int id)
        {
            var item = db.Contacts.Find(id);
            db.Contacts.Remove(item);
            Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Contact> GetAllList()
        {
            return db.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return db.Contacts.Find(id);
        }

        public void insert(Contact contact)
        {
            db.Contacts.Add(contact);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            Save();
        }
    }
}