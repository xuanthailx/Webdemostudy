using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dow
{
    public class MatchDao
    {
        private OnLinewebDbContext db = null;

        public MatchDao()
        {
            db = new OnLinewebDbContext();
        }
        public List<MatchViewModel> ListAllMatch(ref int totalRecord, int pageIndex = 1,
            int pageSize = 5)
        {
            totalRecord = db.MatchUps.Count();
            var model = from m in db.MatchUps
                        join t1 in
                        (from t in db.Teams join m in db.MatchUps on t.ID equals m.Team1 select t) on m.Team1 equals t1.ID
                        join t2 in
                        (from t in db.Teams join m in db.MatchUps on t.ID equals m.Team2
                         select t) on m.Team2 equals t2.ID
                        join g in db.Games on m.GameID equals g.ID
                        join l in db.Locations on m.LocationID equals l.ID
                        select new MatchViewModel()
                        {
                            ID = m.ID,
                            Date = m.Date,
                            StartTime = m.StartTime,
                            Duration = g.Duration,
                            Location = l.Location1,
                            Game = g.Name,
                            FirstTeam = t1.Name,
                            SecondTeam = t2.Name,
                            FirstTeamScore = m.Score1,
                            SecondTeamScore = m.Score2
                        };
            return model.ToList();
        }
    }
}
