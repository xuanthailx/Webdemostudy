using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dow
{
    public class Studentdow
    {
        OnLinewebDbContext db = null;
        public Studentdow()
        {
            db = new OnLinewebDbContext();
        }
        public long Insert(Student entity)
        {
            db.Students.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Student entity)
        {
            try
            {
                var student = db.Students.Find(entity.ID);
                //student.Email = entity.Email;
                //if (!String.IsNullOrEmpty(entity.Password))
                //{
                //    Student.Password = entity.Password;
                //}
                //Student.Role = entity.Role;
                //Student.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public IEnumerable<Student> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Student> model = db.Students;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Student GetByID(int id)
        {
            return db.Students.SingleOrDefault(x => x.ID == id);

        }
        public Student ViewDetail(int id)
        {
            return db.Students.SingleOrDefault(x => x.ID == id);
        }

        public bool Delete(int id)
        {
            try
            {
                var Student = db.Students.Find(id);
                db.Students.Remove(Student);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Student> ListAll()
        {
            return db.Students.ToList();
        }

    }

}
