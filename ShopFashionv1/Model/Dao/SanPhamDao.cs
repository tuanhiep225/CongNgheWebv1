using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SanPhamDao
    {
        ShopFashionDbContext db = null;
        public SanPhamDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<SanPham> getAll()
        {
            return db.SanPhams.ToList();
        }
        public List<SanPham> getAll(ref int totalRecord, int pageIndex = 1, int pageSize = 1)
        {
            totalRecord = db.SanPhams.Count();
            return db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public SanPham getById(int id)
        {
            var sp = db.SanPhams.Where(x => x.MaSP == id).Single();
            return sp;
        }
        public List<SanPham> getListIDCategory(int id,ref int totalRecord, int pageIndex=1, int pageSize=1)
        {
            totalRecord = db.SanPhams.Where(x => x.MaDanhMucSP == id).Count();
            return db.SanPhams.Where(x => x.MaDanhMucSP == id).OrderByDescending(x=>x.NgayCapNhat).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public int Insert(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return sp.MaSP;
        }
        public bool Delete(int id)
        {

            try
            {

                var sp = db.SanPhams.Find(id);
                if (sp == null)
                    return false;
                //SqlParameter[] idparam =
                //{
                //    new SqlParameter {ParameterName="@MaSP",Value= sp.MaSP }
                //};
                //db.Database.ExecuteSqlCommand("EXEC DeleteSp @MaSP", idparam);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpDate(SanPham sp)
        {
            try
            {
                var sanpham = db.SanPhams.Find(sp.MaSP);
                sanpham.MaBST = sp.MaBST;
                sanpham.MaDanhMucSP = sp.MaDanhMucSP;
                sanpham.MaHang = sp.MaHang;
                sanpham.MoTa = sp.MoTa;
                sanpham.NgayCapNhat = sp.NgayCapNhat;
                sanpham.SoLuong = sp.SoLuong;
                sanpham.TenSP = sp.TenSP;
                sanpham.HinhAnhSP = sp.HinhAnhSP;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<SanPham> getTop(int top)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(top).ToList();
        }
       
    }
}
