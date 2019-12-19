using System.Web;
using System.Web.Mvc;

namespace Lab_36_MVC_Framework_Entity_Helpdesk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
