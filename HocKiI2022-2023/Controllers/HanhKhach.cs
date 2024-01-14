using HocKiI2022_2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace HocKiI2022_2023.Controllers
{
    public class HanhKhach : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnterHK()
        {
            return View();
        }

        public IActionResult InsertHK(HANHKHACH hk)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            count = context.SqlInsertHK(hk);
            if (count > 0)
            {
                ViewData["thongbao"] = "Insert thành công";
            }
            else
            {
                ViewData["thongbao"] = "Insert không thành công";

            }
            return View();
        }
    }
}
