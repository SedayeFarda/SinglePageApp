using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinglePageApp;
using SinglePageApp.Context;
using SinglePageApp.Repository;

namespace SinglePageApp.Areas.Admin.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
         DbSinglePageContext db = new DbSinglePageContext();
        GroupsRepository groupsRepository;
        public GroupsController()
        {
                groupsRepository =  new GroupsRepository(db);
        }
        // GET: Admin/Groups
        public ActionResult Index()
        {

            return View(groupsRepository.GetAllGroups());
        }

       [HttpGet]
        public ActionResult Create(int? id)
        {
            Group group = new Group()
            {
                Parent_id = id


            };
            return PartialView(group);
        }

        // POST: Admin/Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name,Parent_id")] Group group)
        {
            if (ModelState.IsValid)
            {
                groupsRepository.insert(group);
                return RedirectToAction("Index");
            }

          
            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group groups = groupsRepository.GetById(id.Value);
            if (groups == null)
            {
                return HttpNotFound();
            }
            
            return PartialView(groups);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Name,Parent_id")] Group group)
        {
            if (ModelState.IsValid)
            {
                groupsRepository.update(group);
               
                return RedirectToAction("Index");
            }
           
            return View(group);
        }

     
        public void Delete(int? id)
        {
            
            bool groups = groupsRepository.delete(id.Value);
           
                
           
            
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group groups = db.Groups.Find(id);
            db.Groups.Remove(groups);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                groupsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
