using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dow;
using Model.EF;
using model.Dow;

namespace Demostudyweb.Controllers
{
    // GET: TeamDetail
    public class TeamDetailController : BaseController
    {
        // GET: Team
        public ActionResult Index(string searchString, int? classidsearch, int page = 1, int pageSize = 5)
        {

            var dao = new TeamDetaildow();
            var model = dao.ListAllPaging(searchString, classidsearch, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Detail(string searchString,int? id, int PageIndex = 1, int pageSize = 5)
        {
            var dao = new TeamDetaildow();
            int totalRecord = 0;            
            var model = dao.ListByID(searchString, id, ref totalRecord, PageIndex, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.Total = totalRecord;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var teamdetail = new TeamDetaildow().ViewDetail(id);
            return View(teamdetail);
        }
        [HttpPost]
        public ActionResult Create(TeamDetail teamdetail)
        {
            if (ModelState.IsValid)
            {
                var dao = new TeamDetaildow();
                long id = dao.Insert(teamdetail);
                if (id > 0)
                {
                    SetAlert("Thêm chi tiết đội thành công", "success");
                    return RedirectToAction("Index", "TeamDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm đội không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(TeamDetail teamdetail)
        {
            if (ModelState.IsValid)
            {
                var dao = new TeamDetaildow();
                var result = dao.Update(teamdetail);
                if (result)
                {
                    SetAlert("Sửa Chi Tiết Đội thành công", "success");
                    return RedirectToAction("Index", "Team");
                }
                else
                {
                    ModelState.AddModelError("", "Câp nhập Chi tiết đội thành công");
                }
            }
            return View("Index");

        }
        public ActionResult Delete(int id)
        {
            new TeamDetaildow().Delete(id);
            return RedirectToAction("Index");

        }
        public void SetViewBag(int selectedemail = 0,int selectedteam = 0)
        {

            
            var dao = new Studentdow();
            ViewBag.StudentID = new SelectList(dao.ListAll(), "ID", "Email", selectedemail);
            var dao1 = new Teamdow();
            ViewBag.TeamID = new SelectList(dao1.ListAll(), "ID", "Name", selectedteam);
        }
    }
}
