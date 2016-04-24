using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class QuanTriVienDao
    {
        ShopFashionDbContext db = null;
        public QuanTriVienDao()
        {
            db = new ShopFashionDbContext();
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.QuanTriViens.Count(x=>x.TaiKhoan==userName && x.MatKhau==passWord);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public QuanTriVien GetByUserName(string username)
        {
           
            return db.QuanTriViens.SingleOrDefault(x => x.TaiKhoan == username);
        }
        public QuanTriVien GetByMaAdmin(int username)
        {
            return db.QuanTriViens.SingleOrDefault(x => x.MaAdmin == username);
        }
        public List<QuanTriVien> ListAll()
        {
            return db.QuanTriViens.ToList();
        }
        public int Insert(QuanTriVien qtv)
        {
            db.QuanTriViens.Add(qtv);
            db.SaveChanges();
            return qtv.MaAdmin;
        }
        public bool Update(QuanTriVien qtv)
        {
            try
            {

                var user = db.QuanTriViens.Find(qtv.MaAdmin);
                user.TenAdmin = qtv.TenAdmin;
                user.MatKhau = qtv.MatKhau;
                user.PhanLoai = qtv.PhanLoai;
                user.Email = qtv.Email;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int ID)
        {
            try
            {

                var user=db.QuanTriViens.Find(ID);
                db.QuanTriViens.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Changes(int id)
        {
            var qtv = db.QuanTriViens.Find(id);
            qtv.PhanLoai = !qtv.PhanLoai;
            db.SaveChanges();
            return qtv.PhanLoai;
        }
    }
}
