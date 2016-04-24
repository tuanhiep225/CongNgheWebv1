using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class BaiVietDao
    {
        ShopFashionDbContext db = null;
        public BaiVietDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<BaiViet> getAll()
        {
            return db.BaiViets.ToList();
        }
        public BaiViet getById(int id)
        {
            var bv = db.BaiViets.Find(id);
            return bv;
        }
        public bool Insert(BaiViet bv)
        {
            try
            {
                db.BaiViets.Add(bv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(BaiViet bv)
        {
            var baiviet = db.BaiViets.Find(bv.MaBaiViet);
            if (baiviet != null)
            {
                try
                {
                    baiviet.TieuDe = bv.TieuDe;
                    baiviet.HinhAnhBaiViet = bv.HinhAnhBaiViet;
                    baiviet.NgayDangBaiViet = bv.NgayDangBaiViet;
                    baiviet.NoiDung = bv.NoiDung;
                    baiviet.MoTa = bv.MoTa;
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
            var bv = db.BaiViets.Find(id);
            if (bv != null)
            {
                try
                {
                    db.BaiViets.Remove(bv);
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
        public List<BaiViet> getTop(int top)
        {
            return db.BaiViets.OrderByDescending(x => x.NgayDangBaiViet).Take(top).ToList();
        }
    }
}
