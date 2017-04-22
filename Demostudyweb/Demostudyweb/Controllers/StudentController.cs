using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dow;
using Model.Dow;
using Model.EF;
namespace Demostudyweb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var dao = new Studentdow();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }


    }
}