using SinglePageApp.Repository;
using System;
using System.Web.Mvc;

namespace SinglePageApp.Areas.Admin.Controllers
{ 
    public class GalleryController : Controller
    {
        GalleryRepository repository = new GalleryRepository();
        GroupGalleryRepository GroupGalleryRepository = new GroupGalleryRepository();
        // GET: Admin/Gallery
        public ActionResult Index()
        {          
            return View("index");
        }
        
        public ActionResult DataGallery()
        {
            return PartialView("_DataGallery", repository.GetAllList());

        }
        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(),"id","Name");
            
            return View();

        }
        [HttpPost]
        public ActionResult Create(Gallery gallery)           
        {
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(),"id","Name");
            
               
                    gallery.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(gallery.UploadFile.FileName);
                    gallery.UploadFile.SaveAs(Server.MapPath("~/images/") + gallery.ImagePath);
                    repository.insert(gallery);
                    return PartialView("_DataGallery", repository.GetAllList());
     
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gallery = repository.GetById(id);
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(), "id", "Name", gallery.GroupGallery_id);
            return View( gallery);
        }
        [HttpPost]
        public ActionResult Edit(Gallery gallery)
        { 
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(), "id", "Name", gallery.GroupGallery_id);
           
                var item = repository.GetById(gallery.id);
                if(gallery.UploadFile!=null)
                {
                 System.IO.File.Delete(Server.MapPath("/images/" + item.ImagePath));
                gallery.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(gallery.UploadFile.FileName);
                gallery.UploadFile.SaveAs(Server.MapPath("/images/" + gallery.ImagePath));

                }             
                repository.update(gallery);
                return PartialView("_DataGallery", repository.GetAllList());
            
           
        }
        [HttpGet]
        public void delete(int id)
        {
            var gallery = repository.GetById(id);
            System.IO.File.Delete(Server.MapPath("/images/" + gallery.ImagePath));
            repository.delete(id);
        }
    }
  }
