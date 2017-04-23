using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dow
{
    public class Gamedow
    {
        OnLinewebDbContext db = null;
        public Gamedow()
        {
            db = new OnLinewebDbContext();
        }
        public List<Game> ListAll()
        {
            return db.Games.ToList();
        }
    }
}
