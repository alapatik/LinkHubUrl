using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities objDb;
        public CategoryDb()
        {
            objDb = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return objDb.tbl_Category;
        }
        public tbl_Category GetById(int id)
        {
            return objDb.tbl_Category.FirstOrDefault(u => u.CategoryId == id);
        }
        public void Insert(tbl_Category category)
        {
            objDb.tbl_Category.Add(category);
            objDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = objDb.tbl_Category.Find(id);
            objDb.tbl_Category.Remove(category);
            objDb.SaveChanges();
        }
        public void Update(tbl_Category category)
        {
            objDb.Entry(category).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
