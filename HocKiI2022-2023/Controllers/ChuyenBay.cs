using HocKiI2022_2023.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace HocKiI2022_2023.Controllers
{
    public class ChuyenBay : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XemThongTinChuyenBay()
        {
            return View();
        }

        public class ThongTinChuyenBayViewModel
        {
            public CHUYENBAY ChuyenBay { get; set; }
            public List<object> HanhKhachChuyenBay { get; set; }
        }

        public IActionResult ThongTinChuyenBay(string MaChuyenbay)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            CHUYENBAY cn = context.SqlGetChuyenBay(MaChuyenbay);
            List<object> result = context.SqlGetHKChuyenBay(MaChuyenbay);
            ThongTinChuyenBayViewModel viewModel = new ThongTinChuyenBayViewModel
            {
                ChuyenBay = cn,
                HanhKhachChuyenBay = result
            };
            return View(viewModel);
        }

        public IActionResult ThemHanhKhachChuyenBay(CHUYENBAY cb,int ChoThuong,int ChoVip)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            ViewData["ChoThuong"] = ChoThuong;
            ViewData["ChoVip"] = ChoVip;
            return View(cb);
        }

        public IActionResult ThemHanhKhachChuyenBay2(CT_CB cb, string HoTen)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            int count = context.SqlInsertHKChuyenBay(cb,HoTen);
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

        public IActionResult UpdateCT_CB(string SoGhe,string MaHK, string TenHK,bool LoaiGhe,string MaCH)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            CT_CB cb = new CT_CB(MaHK, MaCH,SoGhe,LoaiGhe);
            ViewData["HoTen"] = TenHK;
            return View(cb);
        }

        //UpdateHanhKhachTrongChuyen
        public IActionResult UpdateHanhKhachTrongChuyen(CT_CB ct,string HoTen,string MaHKCu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            int count = context.SqlUpdateHanhKhachTrongChuyen(ct, HoTen, MaHKCu);
            if (count > 0)
            {
                ViewData["thongbao"] = "Update thành công";
            }
            else
            {
                ViewData["thongbao"] = "Update không thành công";

            }
            return View();
        }
        //DeleteCT_CB
        public IActionResult DeleteCT_CB(string MaHK, string MaCH)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HocKiI2022_2023.Models.DataContext)) as DataContext;
            int count = context.SqlDeleteHanhKhachTrongChuyen(MaHK,MaCH);
            if (count > 0)
            {
                ViewData["thongbao"] = "Delete thành công";
            }
            else
            {
                ViewData["thongbao"] = "Delete không thành công";

            }
            return View();
        }
    }
}
