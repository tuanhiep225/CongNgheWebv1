using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        public ActionResult Index(int page = 1, int pageSize = 9)
        {
            int totalRecord = 0;
            var list = new SanPhamDao().getAll(ref totalRecord, page, pageSize);
            ViewBag.TotalRecord = totalRecord;
            ViewBag.Page = page;
            int maxPage = 6;
            int totalPage = 0;
            double tam = (double)totalRecord / pageSize;
            totalPage = (int)Math.Ceiling(tam);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(list);
        }
        public ActionResult Category(int id,int page=1,int pageSize=9)
        {
            int totalRecord = 0;
            var list = new SanPhamDao().getListIDCategory(id,ref totalRecord,page,pageSize);
            ViewBag.TotalRecord = totalRecord;
            ViewBag.Page = page;
            int maxPage = 6;
            int totalPage = 0;
            double tam = (double)totalRecord / pageSize;
            totalPage = (int)Math.Ceiling(tam);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage; 
            ViewBag.Next = page + 1; 
            ViewBag.Prev = page - 1;
            ViewBag.id = id;
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult SideBarMenu()
        {
            var list = new DanhMucSPDao().getAllParent();
            ViewBag.dao = new DanhMucSPDao();
            return PartialView(list);
        }
        public ActionResult Detail(int id)
        {
            var entity = new SanPhamDao().getById(id);
            return View(entity);
        }
    }
}
