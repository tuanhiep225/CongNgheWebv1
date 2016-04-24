using Model.Dao;
using ShopFashionv1.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove(commonconstants.USER_SESSEION);
            return RedirectToAction("Login", "Login");
        }
        public ActionResult demo()
        {

            return View();
        }

    }
}
