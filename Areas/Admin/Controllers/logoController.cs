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
        LogoRepository logoRepository = new LogoRepository();

        // GET: Admin/logo
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult List()
        {
            return View(logoRepository.GetAllLogo());

        }
        // GET: Admin/logo/Details/5
       

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public logo logo_1()
        {
            List<logo> logos = logoRepository.GetAllLogo();
            return logos.SingleOrDefault();
        }

        // POST: Admin/logo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FullName,ImagePath")] logo logo,HttpPostedFileBase File)
        {
        
          

                if(logoRepository.CountLogo()==1)
                {
                    ViewBag.num = 1;
                    return View("List",logoRepository.GetAllLogo());
                    
                }
              if(File!=null)
                {
                    logo.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    if (img.Width > 1000)
                        img.Resize(500, 500);
                    //var vFolderPath = Server.MapPath("/images/logo/");
                    //var path = Path.Combine(vFolderPath, logo.ImagePath);
                    
                    img.Save(Server.MapPath("/images/logo/"+logo.ImagePath));                 
                }
                else
                {
                    ModelState.AddModelError("", "لطفا عکس را آپلود کنید");
                    return View("List",logoRepository.GetAllLogo());
                }
                logoRepository.insert(logo);
            
           
            return View("List",logoRepository.GetAllLogo());

        }
        [HttpGet]
        // GET: Admin/logo/Edit/5
        public ActionResult Edit(int id)
        {
           
            logo logo = logoRepository.GetById(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/logo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FullName,ImagePath")] logo logo,HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    System.IO.File.Delete(Server.MapPath("/images/logo/" + logo.ImagePath));
                    File.SaveAs(Server.MapPath("/images/logo/" + logo.ImagePath));
                }
                logoRepository.Update(logo);
            }
            else
            {
                 return View(logo); 
            }
            return View("List",logoRepository.GetAllLogo());
        }

        // GET: Admin/logo/Delete/5
       

        // POST: Admin/logo/Delete/5
       
        
      
    }
}
