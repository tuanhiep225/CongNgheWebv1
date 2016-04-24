using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class BoSTController : BaseController
    {
        //
        // GET: /Admin/BoST/

        public ActionResult Index()
        {
            var list = new BoSuuTapDao().getAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BoSuuTap bst)
        {
            if(ModelState.IsValid)
            {
                var dao = new BoSuuTapDao();
                bool check = dao.Insert(bst);
                if (check)
                {
                    return RedirectToAction("Index", "BoST");
                }
                    
            }
            ModelState.AddModelError("", "Không thể thêm");
            return View("Create", bst);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bst = new BoSuuTapDao().getById(id);
            return View(bst);
        }
        public ActionResult Edit(BoSuuTap bst)
        {
            if(ModelState.IsValid)
            {
                var dao = new BoSuuTapDao();
                bool check = dao.Update(bst);
                if (check)
                {
                    return RedirectToAction("Index", "BoST");
                }
                   
            }
            ModelState.AddModelError("", "Không thể sửa !");
            return View("Edit", bst);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new BoSuuTapDao();
            bool check = dao.Delete(id);
            if (check)
                return RedirectToAction("Index", "BoST");
            else
                return View("Index",dao.getAll());
        }
    }
}
