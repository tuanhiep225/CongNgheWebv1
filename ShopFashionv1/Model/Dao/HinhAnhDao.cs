using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class HinhAnhDao
    {
        ShopFashionDbContext db = null;
       public HinhAnhDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<HinhAnh> getAll()
        {
            return db.HinhAnhs.ToList();
        }
        public bool Insert(HinhAnh enty)
        {
            try
            {
                db.HinhAnhs.Add(enty);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            try
            {
                var enty = db.HinhAnhs.Find(ID);
                if(enty !=null)
                {
                    db.HinhAnhs.Remove(enty);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(HinhAnh enty)
        {
            try
            {
                var hinhanh = db.HinhAnhs.Find(enty.MaHinhAnh);
                hinhanh.TenHinhAnh = enty.TenHinhAnh;
                hinhanh.MaSP = enty.MaSP;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public HinhAnh getById(int id)
        {
            return db.HinhAnhs.Find(id);
        }
    }
}
