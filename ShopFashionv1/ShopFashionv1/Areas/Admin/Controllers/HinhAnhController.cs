using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class HinhAnhController : BaseController
    {
        //
        // GET: /Admin/HinhAnh/

        public ActionResult Index()
        {
            var list = new HinhAnhDao().getAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(HinhAnh enty)
        {
            if(ModelState.IsValid)
            {
                var dao = new HinhAnhDao();
                bool check=dao.Insert(enty);
                if (check)
                {
                    return RedirectToAction("Index", "HinhAnh");
                }
                else
                    ModelState.AddModelError("", "Không thể thêm");
            }
            SetViewBag(enty.MaSP);
            return View("Create");
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var hinhanh = new HinhAnhDao().getById(id);
            SetViewBag(hinhanh.MaSP);
            return View(hinhanh);
        }
        [HttpPost]
        public ActionResult Edit(HinhAnh enty)
        {
            if(ModelState.IsValid)
            {
                var dao = new HinhAnhDao();
                bool check = dao.Update(enty);
                if (check)
                    return RedirectToAction("Index", "HinhAnh");
                else
                    ModelState.AddModelError("", "Không thể sửa hình ảnh này");
            }
            SetViewBag(enty.MaSP);
            return View("Edit", enty);
        }
        public ActionResult Delete(int id)
        {
            var dao = new HinhAnhDao();
            bool check = dao.Delete(id);
            if (check)
                return RedirectToAction("Index", "HinhAnh");
            else
                return View("Index");
        }
        public void SetViewBag(int ? selected=null)
        {
            var dao = new SanPhamDao();
            ViewBag.MaSP = new SelectList(dao.getAll(), "MaSP", "TenSP");
        }
    }
}
