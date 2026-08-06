using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb3C
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
