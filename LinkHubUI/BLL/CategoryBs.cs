using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {
        CategoryDb categoryDb;
        public CategoryBs()
        {
            categoryDb = new CategoryDb();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return categoryDb.GetAll();
        }
        public void DeleteById(int id)
        {
            categoryDb.Delete(id);
        }
        public void Insert(tbl_Category category)
        {
            categoryDb.Insert(category);
        }
    }
}
