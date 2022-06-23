using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SinglePageApp.Repository;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        ProductRepository ProductRepository;
        ProductGroupRepository ProductGroupRepository;
        GroupsRepository GroupsRepository;
        GalleryProductRepository GalleryProductRepository;
        DbSinglePageContext db = new DbSinglePageContext();
        public ProductsController()
        {
            ProductRepository = new ProductRepository(db);
            ProductGroupRepository = new ProductGroupRepository(db);
            GroupsRepository = new GroupsRepository(db);
            GalleryProductRepository = new GalleryProductRepository(db);
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return PartialView("List", ProductRepository.ListProduct());
        }
        // GET: Admin/Products/Details/5


        // GET: Admin/Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Groups = GroupsRepository.GetAllGroups();
            Product product = new Product()
            {
                ImgName = "preview.png"


            };

            return PartialView(product);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Price,Title,Discryption,Tags,Linq,ImgName,UploadFile")] Product product, List<int> Product_Group)
        {

            if (product.UploadFile != null)
            {
                product.ImgName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(product.UploadFile.FileName);
                product.UploadFile.SaveAs(Server.MapPath("~/images/product/") + product.ImgName);
            }

            ProductRepository.insert(product);



            if (Product_Group != null)
            {
                foreach (var item in Product_Group)
                {
                    ProductGroup productGroup = new ProductGroup()
                    {
                        ProductId = product.ProductId,
                        GroupsId = item,

                    };
                    ProductGroupRepository.insert(productGroup);
                }

            }
            return PartialView("List", ProductRepository.ListProduct());


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Price,Title,Discryption,Tags,Linq,ImgName,UploadFile")] Product product, List<int> Product_Group)
        {


            ProductGroupRepository.delete(product.ProductId);


            if (Product_Group != null)
            {
                foreach (var item in Product_Group)
                {
                    ProductGroup productGroup = new ProductGroup()
                    {
                        ProductId = product.ProductId,
                        GroupsId = item,

                    };
                    ProductGroupRepository.insert(productGroup);
                }

            }

            if (product.UploadFile != null)
            {
               
                System.IO.File.Delete(Server.MapPath("/images/product/") + product.ImgName);
                product.UploadFile.SaveAs(Server.MapPath("/images/product/") + product.ImgName);
            }

            ProductRepository.update(product);






            return PartialView("List", ProductRepository.ListProduct());

        }
        // GET: Admin/Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Groups = GroupsRepository.GetAllGroups();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetById(id.Value);
            ViewBag.SelectedGroup = product.ProductGroup;
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Gallery(int id)
        {
            GalleryProduct galleryProduct = new GalleryProduct()
            {
                ProductId=id
            };
            ViewBag.GalleryProduct = GalleryProductRepository.GetAllList();
            return View(galleryProduct);
        }
        [HttpPost]
        public ActionResult CreateGallery(GalleryProduct galleryProduct,HttpPostedFileBase imgUp)
        {
            if (imgUp != null)
            {
                galleryProduct.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(imgUp.FileName);
                WebImage img = new WebImage(imgUp.InputStream);
                img.Resize(100, 100);
                img.Save(Server.MapPath("/images/GalleryProduct/" + galleryProduct.ImagePath));
            }
            GalleryProductRepository.insert(galleryProduct);
            return RedirectToAction("Gallery",new {id=galleryProduct.ProductId });
        }
        public ActionResult deleteGallery(int id)
        {
            var GalleryProduct = GalleryProductRepository.GetById(id);
            GalleryProductRepository.delete(id);
            return RedirectToAction("Gallery", new { id = GalleryProduct.ProductId });
            
        }
        // GET: Admin/Products/Delete/5
        public void Delete(int id)
        {
            
             ProductRepository.delete(id);
           
            
        }

        // POST: Admin/Products/Delete/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ProductRepository.Dispose();

            }
            base.Dispose(disposing);
        }


    }
}
