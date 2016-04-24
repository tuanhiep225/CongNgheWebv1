using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BrandDao
    {
        ShopFashionDbContext db = null;
        public BrandDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<Hang> getAll()
        {
            var list = db.Hangs.ToList();
            return list;
        }
        public bool Update(Hang enty)
        {
            var hang = db.Hangs.Find(enty.MaHang);
            if (hang != null)
            {
                hang.TenHang = enty.TenHang;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public Hang getById(int id)
        {
            return db.Hangs.Find(id);
        }
        public bool Delete(int id)
        {
            var hang = db.Hangs.Find(id);
            if (hang != null)
            {
                try
                {
                    db.Hangs.Remove(hang);
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
        public bool Insert(Hang enty)
        {
            try
            {
                db.Hangs.Add(enty);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
