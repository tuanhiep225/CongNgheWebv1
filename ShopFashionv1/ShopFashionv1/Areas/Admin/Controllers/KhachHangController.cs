using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        //
        // GET: /Admin/KhachHang/

        public ActionResult Index()
        {
            var list = new KhachHangDao().getAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang kh)
        {
            var dao = new KhachHangDao();
            if(ModelState.IsValid)
            {
                bool check = dao.Insert(kh);
                if (check)
                {
                    return RedirectToAction("Index", "KhachHang");
                }

                    ModelState.AddModelError("", "Không thể thêm");
                return View("Index", kh);
            }
            return View("Create", kh);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KhachHangDao();
            var kh = dao.getById(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            var dao = new KhachHangDao();
            if(ModelState.IsValid)
            {
                bool check = dao.Update(kh);
                if (check)
                    return RedirectToAction("Index", "KhachHang");
                else
                {
                    ModelState.AddModelError("", "Không thể Sửa");
                    return View("Index", kh);
                }
                   
            }
            return View("Edit", kh);
        }
        public ActionResult Delete(int id)
        {
            var dao = new KhachHangDao();
            bool check = dao.Delete(id);
            if (check)
                return RedirectToAction("Index", "KhachHang");
            ModelState.AddModelError("", "Không thể Xóa");
            return View("Index", dao.getById(id));
        }
        [HttpPost]
        public JsonResult Changes(int id)
        {
            var result = new KhachHangDao().Changes(id);
            return Json(new {
                PhanLoai = result
            });
        }
    }
}
