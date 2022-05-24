using SinglePageApp.Repository;
using System.Web.Mvc;

namespace SinglePageApp.Controllers
{
    public class HomeController : Controller
    {
        DescriptionRepository descriptionRepository = new DescriptionRepository();
        GroupGalleryRepository GroupGalleryRepository = new GroupGalleryRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyWork()
        {
           
            return PartialView("_MyWork",GroupGalleryRepository.GetAllList() );
        }

        public ActionResult AboutMe()
        {

            return PartialView("_AboutMe",descriptionRepository.GetAllList());
        }

        public ActionResult ContactMe()
        {

            return PartialView("_ContactMe");
        }
        public ActionResult MyServices()
        {

            return PartialView("_MyServices");
        }
    }
}