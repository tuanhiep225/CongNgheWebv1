using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class ThuongHieuController : BaseController
    {
        //
        // GET: /Admin/ThuongHieu/

        public ActionResult Index()
        {
            var list = new BrandDao().getAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Hang enty)
        {
            if(ModelState.IsValid)
            {
                var dao = new BrandDao();
                bool check = dao.Insert(enty);
                if (check)
                {
                    return RedirectToAction("Index", "ThuongHieu");
                }
                else
                    ModelState.AddModelError("", "Không thể thêm");
            }
            return View("Create", enty);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao =new BrandDao();
            var hang = dao.getById(id);
            return View(hang);
        }
        [HttpPost]
        public ActionResult Edit(Hang enty)
        {
            if(ModelState.IsValid)
            {

                var dao = new BrandDao();
                bool check= dao.Update(enty);
                if (check)
                    return RedirectToAction("Index", "ThuongHieu");
                else
                    ModelState.AddModelError("", "Không thể thêm");
            }
            return View("Edit", enty);

        }
    }
}
