using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication_StateManagement_Clone
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
