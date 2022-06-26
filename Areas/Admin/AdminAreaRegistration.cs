using System.Web.Mvc;

namespace SinglePageApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional }
            );

            
        }
    }
}