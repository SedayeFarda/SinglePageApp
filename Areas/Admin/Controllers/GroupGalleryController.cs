using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class GroupGalleryController : Controller
    {
        GroupGalleryRepository repository = new GroupGalleryRepository();
        // GET: Admin/GroupGallery
        public ActionResult Index()
        {           
            return View();           
        }

        public ActionResult DataGroupGallery()
        {
            return PartialView("_DataGroupGallery", repository.GetAllList());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");

        }

        [HttpPost]
        public ActionResult Create(GroupGallery groupGallery)
        {
            if(ModelState.IsValid)
            {
                repository.insert(groupGallery);
                return PartialView("_DataGroupGallery", repository.GetAllList());

            }
            return View("_Create", groupGallery);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GroupGallery = repository.GetById(id);
            return PartialView("_Edit", GroupGallery);
        }
        [HttpPost]
        public ActionResult Edit(GroupGallery groupGallery)
        {
            if(ModelState.IsValid)
            {
                repository.update(groupGallery);
                return PartialView("_DataGroupGallery", repository.GetAllList());
            }
            return PartialView("_Edit",groupGallery);

        }
    }
}