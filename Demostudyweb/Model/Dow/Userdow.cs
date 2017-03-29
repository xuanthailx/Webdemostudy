using Model.EF;
using System;
using System.Linq;

namespace model.Dow
{
    public class Userdow
    {
        DemowebdbContext db = null;
        public Userdow()
        {
            db = new DemowebdbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x=>x.Username == userName);

        }

        public int login(String userName, String password)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName );
            if (result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password) return 1;
                    else return -2;
                }
            }
        }

        public object GetuserID(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
