using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private LinkHubDbEntities objDb;
        public UserDb()
        {
            objDb = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return objDb.tbl_User;
        }
        public tbl_User GetById(int id)
        {
            return objDb.tbl_User.FirstOrDefault(u => u.UserId == id);
        }
        public void Insert(tbl_User user)
        {
            objDb.tbl_User.Add(user);
            objDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = objDb.tbl_User.Find(id);
            objDb.tbl_User.Remove(user);
            objDb.SaveChanges();
        }
        public void Update(tbl_User user)
        {
            objDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
