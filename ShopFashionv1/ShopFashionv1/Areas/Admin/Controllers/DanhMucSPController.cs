using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class DanhMucSPController : BaseController
    {
        //
        // GET: /Admin/DanhMucSP/

        public ActionResult Index()
        {
            var result = new DanhMucSPDao().getAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DanhMucSPDao dao = new DanhMucSPDao();
            var rs = dao.getById(id);
            SetViewBag(rs.MaDanhMucSPCha);
            return View(rs);
        }
        [HttpPost]
        public ActionResult Edit(DanhMucSP sp)
        {
            if(ModelState.IsValid)
            {
                var dao = new DanhMucSPDao();
                bool check = dao.Update(sp);
                if (check)
                {
                    return RedirectToAction("Index", "DanhMucSP");
                }
                else
                    ModelState.AddModelError("", "Không thể sửa");
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            var dao = new DanhMucSPDao();
            bool check = dao.Delete(id);
            if(check)
            {
                return RedirectToAction("Index", "DanhMucSP");
            }
            return View("Index");
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMucSP dm)
        {
            if(ModelState.IsValid)
            {
                var dao = new DanhMucSPDao();
                bool check = dao.Insert(dm);
                if (check)
                    return RedirectToAction("Index", "DanhMucSP");
                else
                    ModelState.AddModelError("", "Không thể thêm!");
            }
            return View("Index");
        }
        public void SetViewBag(int? selected = null)
        {
            var dao = new DanhMucSPDao();
            ViewBag.MaDanhMucSPCha = new SelectList(dao.getAllParent(), "MaDanhMucSP", "TenDanhMucSP", selected);
        }
    }
}
