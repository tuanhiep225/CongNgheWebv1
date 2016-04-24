using Model.Dao;
using Model.EF;
using ShopFashionv1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class QuanTriController : BaseController
    {
        //
        // GET: /Admin/QuanTri/

        public ActionResult Index()
        {
           
            var ngoc= new QuanTriVienDao().ListAll();
            return View(ngoc);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuanTriVien qtv)
        {
            if(ModelState.IsValid)
            {
                var dao = new QuanTriVienDao();
                int maqtv = dao.Insert(qtv);
                if(maqtv>0)
                {
                    return RedirectToAction("Index", "QuanTri");
                }
                else
                {
                    ModelState.AddModelError("", "Khong the them");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new QuanTriVienDao();
            var qtv = dao.GetByMaAdmin(id);
            return View(qtv);
        }
        [HttpPost]
        public ActionResult Edit(QuanTriVien qtv)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuanTriVienDao();
                var rs = dao.Update(qtv);
                if (rs)
                {
                    return RedirectToAction("Index","QuanTri");
                }
                else
                {
                    ModelState.AddModelError("", "Khong the them");
                }
            }
            return View("Index");
        }
       public ActionResult Delete(int id)
        {
            var rs = new QuanTriVienDao().Delete(id);
           if(rs)
           {
               return RedirectToAction("Index", "QuanTri");
           }
           return View("Index");
        }
        [HttpPost]
        public JsonResult Changes(int id)
        {
            var result = new QuanTriVienDao().Changes(id);
            return Json(new
            {
                PhanLoai = result
            });
        }
    }
}
