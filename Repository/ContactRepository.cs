using SinglePageApp.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePageApp
{
    public class ContactRepository:IContact
    {
        DbSinglePageContext _db;
        public ContactRepository(DbSinglePageContext db)
        {
            _db = db; 
        }
        public void Delete(int id)
        {
            var item = _db.Contacts.Find(id);
            _db.Contacts.Remove(item);
            Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<Contact> GetAllList()
        {
            return _db.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _db.Contacts.Find(id);
        }

        public void insert(Contact contact)
        {
            _db.Contacts.Add(contact);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _db.Entry(contact).State = EntityState.Modified;
            Save();
        }
    }
}