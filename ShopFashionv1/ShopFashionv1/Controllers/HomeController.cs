using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
namespace ShopFashionv1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.listnewsp = new SanPhamDao().getTop(5);
            ViewBag.listbaiviet = new BaiVietDao().getTop(2);
            return View();
        }
        [ChildActionOnly]
        public ActionResult DanhMuc()
        {
            var model = new DanhMucSPDao().getAllParent();
            ViewBag.dao = new DanhMucSPDao();
            return PartialView(model);
        }
    }
}
