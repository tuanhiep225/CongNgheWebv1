using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class BaiVietController : BaseController
    {
        //
        // GET: /Admin/BaiViet/

        public ActionResult Index()
        {
            var list = new BaiVietDao().getAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BaiViet bv)
        {
            bv.NgayDangBaiViet = DateTime.Now;
            if (ModelState.IsValid)
            {
                var dao = new BaiVietDao();
                bool check = dao.Insert(bv);
                if (check)
                {
                    return RedirectToAction("Index", "BaiViet");
                }
                    ModelState.AddModelError("", "Khong the them");
                    return View("Create", bv);
            }

            ModelState.AddModelError("", "Khong the them");
            return View("Create",bv);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new BaiVietDao();
            var bv = dao.getById(id);
            return View(bv);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BaiViet bv)
        {
            if(ModelState.IsValid)
            {
                var dao = new BaiVietDao();
                var check = dao.Update(bv);
                if (check)
                    return RedirectToAction("Index", "BaiViet");
                ModelState.AddModelError("", "Không thể thêm");
                return View("Edit", bv);
            }
            return View("Edit", bv);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new BaiVietDao();
            var check = dao.Delete(id);
            if (check)
                return RedirectToAction("Index", "BaiViet");
            return View("Index", dao.getAll());
        }
    }
}
