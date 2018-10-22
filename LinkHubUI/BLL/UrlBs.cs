using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private URLdb db;
        public UrlBs()
        {
            db = new URLdb();
        }
        public IEnumerable<tbl_Url> GetAll()
        {
            return db.GetAll();
        }
        public void Insert(tbl_Url url)
        {
            db.Insert(url);
        }
    }
}
