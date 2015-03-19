using System.Web.Mvc;

namespace Surrogat.Areas.CentralBank
{
    public class CentralBankAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CentralBank";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CentralBank_default",
                "CentralBank/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}