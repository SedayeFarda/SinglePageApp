using SinglePageApp.Context;
using SinglePageApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SinglePageApp.Repository
{
    public class GroupsRepository:IGroup 
    {
        DbSinglePageContext db;
        public GroupsRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
        public bool delete(int id)
        {
            try
            {
                Group groups = GetById(id);
                if (groups.ProductGroups.Any())
                {
                db.ProductsGroups.RemoveRange(groups.ProductGroups);
                }
               if(groups.Groups.Any())
                {
                    db.Groups.RemoveRange(groups.Groups);
                }
                db.Groups.Remove(groups);
                save();
                return true;
            }

            catch
            {
                return false;

            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Group> GetAllGroups()
        {
            return db.Groups.ToList();
        }

        public Group GetById(int id)
        {
            return db.Groups.Find(id);
        }

        public bool insert(Group groups)
        {
            try
            {
                db.Groups.Add(groups);
                save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void save()
        {
            try
            {

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        public bool update(Group groups)
        {
            try
            {
                db.Entry(groups).State = System.Data.Entity.EntityState.Modified;
                save();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}