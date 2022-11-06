using SinglePageApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class GroupGalleryController : Controller
    {
        DbSinglePageContext db = new DbSinglePageContext();
        GroupGalleryRepository GroupGallery_repository;
        public GroupGalleryController()
        {
            GroupGallery_repository = new GroupGalleryRepository(db);
        }
        // GET: Admin/GroupGallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataGroupGallery()
        {
            return PartialView("_DataGroupGallery", GroupGallery_repository.GetAllList());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");

        }

        [HttpPost]
        public ActionResult Create(GroupGalleries groupGallery)
        {
            if (ModelState.IsValid)
            {
                GroupGallery_repository.insert(groupGallery);
                return PartialView("_DataGroupGallery", GroupGallery_repository.GetAllList());

            }
            return View("_Create", groupGallery);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GroupGallery = GroupGallery_repository.GetById(id);
            return PartialView("_Edit", GroupGallery);
        }
        [HttpPost]
        public ActionResult Edit(GroupGalleries groupGallery)
        {
            if (ModelState.IsValid)
            {
                GroupGallery_repository.update(groupGallery);
                return PartialView("_DataGroupGallery", GroupGallery_repository.GetAllList());
            }
            return PartialView("_Edit", groupGallery);

        }
    }
}