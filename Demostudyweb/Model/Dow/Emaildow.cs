using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dow
{
    public class Emaildow
    {
        OnLinewebDbContext db = null;
        public Emaildow()
        {
            db = new OnLinewebDbContext();

        }
        public List<Email> ListAll()
        {
            return db.Emails.ToList();
        }
    }
}
