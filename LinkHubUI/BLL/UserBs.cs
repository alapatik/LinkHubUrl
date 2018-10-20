using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        UserDb db;
        public UserBs()
        {
            db = new UserDb();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return db.GetAll();
        }
    }
}
