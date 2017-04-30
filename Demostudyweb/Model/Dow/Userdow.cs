using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
namespace model.Dow
{
    public class Userdow
    {
        OnLinewebDbContext db = null;
        public Userdow()
        {
            db = new OnLinewebDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Email = entity.Email;
                if (!String.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Role = entity.Role;
                //user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public User GetByID(string email)
        {
            return db.Users.SingleOrDefault(x => x.Email == email);

        }
        public User ViewDetail(int id)
        {
            return db.Users.SingleOrDefault(x => x.ID == id);
        }
        public int login(string email, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == 0)
                {
                    return -1;
                }
                else
                {                   
                        if (result.Password != password)
                            return -2;
                        else
                        {
                            if (result.Role == "1")
                            {
                                return 3;
                            }
                            else return 4;
                        }

                        //if (result.Password == password)
                        //    return 1;
                        //else return -2;
                    
                   
                }
            }
        }
        public object GetuserID(string userName)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
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
