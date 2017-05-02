﻿using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dow
{
    public class TeamDetaildow
    {
        OnLinewebDbContext db = null;
        public TeamDetaildow()
        {
            db = new OnLinewebDbContext();
        }
        public long Insert(TeamDetail entity)
        {
            db.TeamDetails.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(TeamDetail entity)
        {
            try
            {
                var teamdetail = db.TeamDetails.Find(entity.ID);
                teamdetail.TeamID = entity.TeamID;
                teamdetail.StudentID = entity.StudentID;
                teamdetail.CheckIn = entity.CheckIn;
                //team.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TeamDetail GetByID(int id)
        {
            return db.TeamDetails.SingleOrDefault(x => x.ID == id);

        }
        public TeamDetail ViewDetail(int id)
        {
            return db.TeamDetails.SingleOrDefault(x => x.ID == id);
        }
        public IEnumerable<TeamDetail> ListAllPaging(string searchString, int? classidsearch, int page, int pageSize)
        {
            IQueryable<TeamDetail> model = db.TeamDetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TeamID.Equals(classidsearch));
               
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<TeamViewModel> ListByID(string searchString,int? id, ref int totalRecord, int PageIndex, int pageSize)
        {
           
            var model = from a in db.Teams
                        join c in db.TeamDetails
                        on a.ID equals c.TeamID                       
                        join b in db.Games
                        on a.GameID equals b.ID
                        join d in db.Students
                        on c.StudentID equals d.ID                        
                        select new TeamViewModel()
                        {
                            ID = c.ID,
                            TeamName = a.Name,
                            StudentName = d.LastName,
                            Checkin = c.CheckIn,
                            StudentEmail = d.Email,
                            GameName = b.Name
                        };
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TeamName.Contains(searchString));

            }
            //.AsEnumerable().Select(x => new TeamViewModel()
            //{
            //    ID = x.ID,
            //    TeamName = x.TeamName,
            //    StudentName = x.StudentName,
            //    GameName = x.GameName,
            //    Checkin = x.Checkin
            //});
            totalRecord = model.Where(x => x.TeamName.Contains(searchString)).Count();
            return model.OrderByDescending(x=>x.ID).ToPagedList(PageIndex,pageSize);
            
        }
        public bool Delete(int id)
        {
            try
            {
                var teamdetail = db.TeamDetails.Find(id);
                db.TeamDetails.Remove(teamdetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int ChangeCheckin(int id)
        {
            var teamdetail = db.TeamDetails.Find(id);
            if (teamdetail.CheckIn == 0)
            {
                 teamdetail.CheckIn = 1;
            }
            else {
                teamdetail.CheckIn = 0;

            }
            db.SaveChanges();
            return teamdetail.CheckIn;




        }
    }
}
