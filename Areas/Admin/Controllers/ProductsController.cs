using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using SinglePageApp.Repository;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        ProductRepository ProductRepository = new ProductRepository();
       

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _List()
        {
            return PartialView(ProductRepository.ListProduct());
        }
        // GET: Admin/Products/Details/5
       

        // GET: Admin/Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Title,Discryption,Tags,Linq,ImgName,UploadFile")] Product product)
        {
            product.ImgName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(product.UploadFile.FileName);
           product.UploadFile.SaveAs(Server.MapPath("~/images/product/") + product.ImgName);
            ProductRepository.insert(product);

            return PartialView("_List",ProductRepository.ListProduct());
        }

        // GET: Admin/Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetById(id.Value);
            TempData["img"] = "/images/product/" + product.ImgName;
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Title,Discryption,Tags,Linq,ImgName,UploadFile")] Product product)
        {
            if(product.UploadFile!=null)
            {
 System.IO.File.Delete(Server.MapPath("/images/product/") + product.ImgName);
            product.UploadFile.SaveAs(Server.MapPath("/images/product/") + product.ImgName);
            }
           
          bool update=ProductRepository.update(product);
            ViewBag.up = update;
            return PartialView("_List", ProductRepository.ListProduct());

        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
       
     

       
    }
}
