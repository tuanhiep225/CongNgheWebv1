using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Controllers
{
    public class BaiVietController : Controller
    {
        //
        // GET: /BaiViet/

        public ActionResult Index()
        {
            var list = new BaiVietDao().getAll();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult MenuBaiViet()
        {
            var list = new BaiVietDao().getAll();
            return PartialView(list);
        }
        public ActionResult Detail(int id)
        {
            var entity = new BaiVietDao().getById(id);
            return View(entity);
        }
    }
}
