using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BoSuuTapDao
    {
        ShopFashionDbContext db = null;
        public BoSuuTapDao()
        {
            db = new ShopFashionDbContext();
        }
        public List<BoSuuTap> getAll()
        {
            return db.BoSuuTaps.ToList();
        }
        public BoSuuTap getById(int id)
        {
           return db.BoSuuTaps.Find(id);
        }
        public bool Insert(BoSuuTap enty)
        {
            try
            {
                db.BoSuuTaps.Add(enty);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(BoSuuTap enty)
        {
            var bst = db.BoSuuTaps.Find(enty.MaBST);
            if(bst!=null)
            {
                try
                {
                    bst.TenBST = enty.TenBST;
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
            var bst = db.BoSuuTaps.Find(id);
            if(bst!=null)
            {
                try
                {
                    db.BoSuuTaps.Remove(bst);
                    db.SaveChanges();
                    return true;
                }
                catch
                { return false; }
            }
            return false;
        }
    }
}
