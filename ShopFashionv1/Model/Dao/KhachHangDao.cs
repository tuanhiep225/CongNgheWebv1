using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class KhachHangDao
    {
        ShopFashionDbContext db = null;
        public KhachHangDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<KhachHang> getAll()
        {
            return db.KhachHangs.ToList();
        }
        public KhachHang getById(int id)
        {
            var kh = db.KhachHangs.Find(id);
            return kh;
        }
        public bool Insert(KhachHang kh)
        {
            try
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(KhachHang kh)
        {
            var khachhang = db.KhachHangs.Find(kh.MaKhachHang);
            if(khachhang!=null)
            {
                try
                {
                    khachhang.TenKhachHang = kh.TenKhachHang;
                    khachhang.MatKhau = kh.MatKhau;
                    khachhang.SoDienThoai = kh.SoDienThoai;
                    khachhang.Email = kh.Email;
                    khachhang.DiaChi = kh.DiaChi;
                    khachhang.PhanLoai = kh.PhanLoai;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            var kh = db.KhachHangs.Find(id);
            if (kh != null)
            {
                try
                {
                    db.KhachHangs.Remove(kh);
                    db.SaveChanges();
                    return true;
                }catch
                {
                    return false;
                }
            }
            return false;
        }
       public bool Changes(int id)
        {
            var kh = db.KhachHangs.Find(id);
            kh.PhanLoai = !kh.PhanLoai;
            db.SaveChanges();
            return kh.PhanLoai;
        }
    }
}
