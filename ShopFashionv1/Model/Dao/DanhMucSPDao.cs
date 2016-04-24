using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DanhMucSPDao
    {
        ShopFashionDbContext db = null;
       public DanhMucSPDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<DanhMucSP> getAll()
        {
            var list = db.DanhMucSPs.ToList();
            return list;
        }
        public DanhMucSP getById(int id)
        {
            var result = db.DanhMucSPs.Where(x => x.MaDanhMucSP == id).Single();
            return result;
        }
        public List<DanhMucSP> getByIdParent(int id)
        {
            var result = db.DanhMucSPs.Where(x => x.MaDanhMucSPCha == id).ToList();
            return result;
        }
        public List<DanhMucSP> getAllChild()
        {
            var result = db.DanhMucSPs.Where(x => x.MaDanhMucSPCha != null).ToList();
            return result;
        }
        public List<DanhMucSP> getAllParent()
        {
            return db.DanhMucSPs.Where(x => x.MaDanhMucSPCha ==null).ToList();
        }
        public bool Update(DanhMucSP dmsp)
        {
            try
            {

                var danhmuc = db.DanhMucSPs.Find(dmsp.MaDanhMucSP);
                danhmuc.TenDanhMucSP = dmsp.TenDanhMucSP;
                danhmuc.MaDanhMucSPCha = dmsp.MaDanhMucSPCha;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var danhmuc = db.DanhMucSPs.Find(id);
            if (danhmuc == null)
                return false;
            var list = db.SanPhams.Where(x => x.MaDanhMucSP == id).ToList();
            try
            {
                foreach (SanPham sp in list)
                {
                    db.SanPhams.Remove(sp);
                }
                db.DanhMucSPs.Remove(danhmuc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Insert(DanhMucSP dm)
        {
            try
            {
                db.DanhMucSPs.Add(dm);
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
