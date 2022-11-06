using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SinglePageApp;
using SinglePageApp.Repository;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class logoController : Controller
    {
        LogoRepository _logoRepository;
        public logoController(LogoRepository logoRepository)
        {
            _logoRepository = logoRepository;
        }
        // GET: Admin/logo
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult _List()
        {
            return PartialView(_logoRepository.GetAllLogo());

        }
        // GET: Admin/logo/Details/5


        [HttpGet]
        public ActionResult _Create()
        {
            return PartialView();
        }

        public logo logo_1()
        {
            List<logo> logos = _logoRepository.GetAllLogo();
            return logos.SingleOrDefault();
        }

        // POST: Admin/logo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "id,FullName,ImagePath")] logo logo, HttpPostedFileBase File)
        {
            if (_logoRepository.CountLogo() == 1)
            {
                ViewBag.num = 1;
                return PartialView("_List", _logoRepository.GetAllLogo());

            }
            if (File != null)
            {
                logo.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(File.FileName);
                WebImage img = new WebImage(File.InputStream);
                if (img.Width > 1000)
                    img.Resize(500, 500);
                //var vFolderPath = Server.MapPath("/images/logo/");
                //var path = Path.Combine(vFolderPath, logo.ImagePath);

                img.Save(Server.MapPath("/images/logo/" + logo.ImagePath));
            }
            else
            {
                ModelState.AddModelError("", "لطفا عکس را آپلود کنید");
                return PartialView("_List", _logoRepository.GetAllLogo());
            }
            _logoRepository.insert(logo);


            return PartialView("_List", _logoRepository.GetAllLogo());

        }
        [HttpGet]
        // GET: Admin/logo/Edit/5
        public ActionResult Edit(int id)
        {

            logo logo = _logoRepository.GetById(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View("Create", logo);
        }

        // POST: Admin/logo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FullName,ImagePath")] logo logo, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    System.IO.File.Delete(Server.MapPath("/images/logo/" + logo.ImagePath));
                    File.SaveAs(Server.MapPath("/images/logo/" + logo.ImagePath));
                }
                _logoRepository.Update(logo);
            }
            else
            {
                return View(logo);
            }
            return View("List", _logoRepository.GetAllLogo());
        }

        // GET: Admin/logo/Delete/5


        // POST: Admin/logo/Delete/5
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logoRepository.Dispose();

            }
            base.Dispose(disposing);
        }


    }
}
