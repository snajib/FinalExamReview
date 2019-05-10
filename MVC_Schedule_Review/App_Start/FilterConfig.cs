using System.Web;
using System.Web.Mvc;

namespace MVC_Schedule_Review
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
