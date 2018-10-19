using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class URLdb
    {
        LinkHubDbEntities db;
        public URLdb()
        {
            db = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }
        public tbl_Url GetById(int Id)
        {
            return db.tbl_Url.FirstOrDefault(u => u.UrlId == Id);
        }
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            SaveChanges();
        }
        public void Delete(int Id)
        {
            tbl_Url url = db.tbl_Url.Find(Id);
            db.tbl_Url.Remove(url);
            SaveChanges();
        }
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
