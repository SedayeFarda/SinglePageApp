using SinglePageApp.Repository;
using System;
using System.Web.Mvc;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        DbSinglePageContext db = new DbSinglePageContext();
        GalleryRepository GalleryRepository;
        GroupGalleryRepository GroupGalleryRepository;
        public GalleryController()
        {
            GalleryRepository = new GalleryRepository(db);
            GroupGalleryRepository = new GroupGalleryRepository(db);
        }

        // GET: Admin/Gallery
        public ActionResult Index()
        {
            return View("index");
        }

        public ActionResult DataGallery()
        {
            return PartialView("_DataGallery", GalleryRepository.GetAllList());

        }
        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(), "id", "Name");

            return View();

        }
        [HttpPost]
        public ActionResult Create(Gallery gallery)
        {
            //ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(),"id","Name");


            gallery.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(gallery.UploadFile.FileName);
            gallery.UploadFile.SaveAs(Server.MapPath("/images/gallery") + gallery.ImagePath);
            GalleryRepository.insert(gallery);
            return PartialView("_DataGallery", GalleryRepository.GetAllList());

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gallery = GalleryRepository.GetById(id);
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(), "id", "Name", gallery.GroupGallery_id);
            return View(gallery);
        }
        [HttpPost]
        public ActionResult Edit(Gallery gallery)
        {
            ViewBag.GroupGallery_id = new SelectList(GroupGalleryRepository.GetAllList(), "id", "Name", gallery.GroupGallery_id);

            var item = GalleryRepository.GetById(gallery.id);
            if (gallery.UploadFile != null)
            {
                System.IO.File.Delete(Server.MapPath("/images/" + item.ImagePath));
                gallery.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(gallery.UploadFile.FileName);
                gallery.UploadFile.SaveAs(Server.MapPath("/images/" + gallery.ImagePath));

            }
            GalleryRepository.update(gallery);
            return PartialView("_DataGallery", GalleryRepository.GetAllList());


        }
        [HttpGet]
        public void delete(int id)
        {
            var gallery = GalleryRepository.GetById(id);
            System.IO.File.Delete(Server.MapPath("/images/" + gallery.ImagePath));
            GalleryRepository.delete(id);
        }
    }
}
