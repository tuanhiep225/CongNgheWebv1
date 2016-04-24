using ShopFashionv1.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using ShopFashionv1.common;
namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {

                var dao = new QuanTriVienDao();
                var result = dao.Login(model.Username, model.Password);
                if(result==true)
                {
                    var admin = dao.GetByUserName(model.Username);
                    var userSession = new adminlogin();
                    userSession.TaiKhoan = admin.TaiKhoan;
                    userSession.MaAdmin = admin.MaAdmin;
                    userSession.TenAdmin = admin.TenAdmin;
                    Session.Add(commonconstants.USER_SESSEION,userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập không đúng !");
                }
            }
            return View("Index");
        }
    }
}
