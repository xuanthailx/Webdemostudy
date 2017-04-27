
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dow
{
    public class Teamdow
    {
        OnLinewebDbContext db = null;
        public Teamdow()
        {
            db = new OnLinewebDbContext();
        }
        public long Insert(Team entity)
        {
            db.Teams.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Team entity)
        {
            try
            {
                var team = db.Teams.Find(entity.ID);
                team.Name = entity.Name;               
                team.ClassID = entity.ClassID;
                team.GameID = entity.GameID;
                //team.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Team GetByID(int id)
        {
            return db.Teams.SingleOrDefault(x => x.ID == id);

        }
        public Team ViewDetail(int id)
        {
            return db.Teams.SingleOrDefault(x => x.ID == id);
        }
        public IEnumerable<Team> ListAllPaging(string searchString,int? classidsearch, int page, int pageSize)
        {
            IQueryable<Team> model = db.Teams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ClassID.Value.Equals(classidsearch));
                model = model.Where(y => y.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var team = db.Teams.Find(id);
                db.Teams.Remove(team);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Team> ListAll()
        {
            return db.Teams.ToList();
        }
    }
}
