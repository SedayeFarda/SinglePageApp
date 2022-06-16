using SinglePageApp.Repository;
using System.Web.Mvc;

namespace SinglePageApp.Controllers
{
    public class HomeController : Controller
    {
        DbSinglePageContext db = new DbSinglePageContext();
        DescriptionRepository descriptionRepository;
        GroupGalleryRepository GroupGalleryRepository;
        public HomeController()
        {
            descriptionRepository = new DescriptionRepository(db);
            GroupGalleryRepository = new GroupGalleryRepository(db);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyWork()
        {

            return PartialView("_MyWork", GroupGalleryRepository.GetAllList());
        }

        public ActionResult AboutMe()
        {

            return PartialView("_AboutMe", descriptionRepository.GetAllList());
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