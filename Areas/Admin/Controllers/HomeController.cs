using SinglePageApp.Repository;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SinglePageApp.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DbSinglePageContext db = new DbSinglePageContext();
        DescriptionRepository repository;
        public HomeController()
        {
            repository = new DescriptionRepository(db);
        }

        public  ActionResult logout()
        {
            FormsAuthentication.SignOut();
          return  Redirect("/");
        }

    
        [HttpPost]
        public ActionResult Login(User user)
        {
            var username_and_pass = db.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password);
            if (username_and_pass == true)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return RedirectToAction("index","Products");
            }
            else
            {
                ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است");
                return View(user);
            }
            
        }
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Description description, HttpPostedFileBase upload, string CKEditorFuncNum)
        {
            if (upload != null)
            {

                description.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName);
                string path = Server.MapPath("/images/");
                upload.SaveAs(path + description.ImagePath);
                string vImagePath = Url.Content("/images/" + description.ImagePath);
                string vMessage = "تصویر با موفقیت ذخیره شد";
                string vOutput = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + vImagePath + "\", \"" + vMessage + "\");</script></body></html>";
                return Content(vOutput);
            }
            else if (ModelState.IsValid)
            {
                repository.insert(description);
                return RedirectToAction("index");
            }

            else
            {
                return View(description);
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.GetById(id));


        }
        [HttpPost]
        public ActionResult Edit(Description description, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    try
                    {

                        System.IO.File.Delete(Server.MapPath("/images/" + description.ImagePath));

                    }
                    catch
                    {


                    }
                    description.ImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(File.FileName);
                    File.SaveAs(Server.MapPath("/images/" + description.ImagePath));
                }
                repository.Update(description);
                return RedirectToAction("index");
            }
            return View(description);
        }

        public ActionResult Delete(int id)
        {
            var description = repository.GetById(id);
            try
            {

                System.IO.File.Delete(Server.MapPath("/images/" + description.ImagePath));
            }
            catch
            {

            }
            repository.Delete(id);
            return RedirectToAction("index");
        }
    }
}