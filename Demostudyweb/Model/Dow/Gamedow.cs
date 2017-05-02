using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dow
{
    public class Gamedow
    {
        OnLinewebDbContext db = null;
        public Gamedow()
        {
            db = new OnLinewebDbContext();
        }
        public long Insert(Game entity)
        {
            db.Games.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Game entity)
        {
            try
            {
                var game = db.Games.Find(entity.ID);
                game.Name = entity.Name;
                game.Type = entity.Type;
                game.MaxPeopleAllowed = entity.MaxPeopleAllowed;
                game.Duration = entity.Duration;
                game.Champion = entity.Champion;                            
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Game> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Game> model = db.Games;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Game GetByID(string name)
        {
            return db.Games.SingleOrDefault(x => x.Name == name);

        }
        public Game ViewDetail(int id)
        {
            return db.Games.SingleOrDefault(x => x.ID == id);
        }
        public List<Game> ListAll()
        {
            return db.Games.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var game = db.Games.Find(id);
                db.Games.Remove(game);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
