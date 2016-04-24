using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopFashionv1.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        //
        // GET: /Admin/SanPham/

        public ActionResult Index()
        {
            SanPhamDao dao = new SanPhamDao();
            var resutl = dao.getAll();
            return View(resutl);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            sp.NgayCapNhat = DateTime.Now;
            if(ModelState.IsValid)
            {
                sp.NgayCapNhat = DateTime.Now;
                SanPhamDao dao = new SanPhamDao();
                int masp = dao.Insert(sp);
                if (masp > 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                    ModelState.AddModelError("", "Khong the them");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SanPhamDao dao = new SanPhamDao();
            var result = dao.getById(id);
            SetViewBag(result.MaDanhMucSP,result.MaHang,result.MaBST);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            if(ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                bool check = dao.UpDate(sp);
                if (check)
                   return RedirectToAction("Index", "SanPham");
                else
                    ModelState.AddModelError("", "Xảy ra lối khi sửa");
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            var rs = new SanPhamDao().Delete(id);
            if(rs)
            {
                try
                {
                    return RedirectToAction("Index", "SanPham");
                }
                catch
                {
                    ModelState.AddModelError("", "Không thể xóa sản phẩm này");
                }
            }
            return View("Index",new SanPhamDao().getAll());
        }
        public void SetViewBag(int?  selectedIdC=null,int ? selectedIdB=null,int ?selectedCl=null)
        {
            var DMdao= new DanhMucSPDao();
            var BRdao=new BrandDao();
            var BstDao = new BoSuuTapDao();
            ViewBag.MaDanhMucSP = new SelectList(DMdao.getAllChild(), "MaDanhMucSP", "TenDanhMucSP", selectedIdC);
            ViewBag.MaHang = new SelectList(BRdao.getAll(), "MaHang", "TenHang", selectedIdB);
            ViewBag.MaBST = new SelectList(BstDao.getAll(), "MaBST", "TenBST", selectedCl);
        }
    }
}
