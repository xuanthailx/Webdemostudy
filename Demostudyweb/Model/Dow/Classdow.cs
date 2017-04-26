using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dow
{
    public class Classdow
    {
        OnLinewebDbContext db = null;
        public Classdow()
        {
            db = new OnLinewebDbContext();
        }
        public List<Class> ListAll()
        {
            return db.Classes.ToList();
        }
    }
}
