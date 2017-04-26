using Model.Dow;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demostudyweb.Controllers
{
    public class TeamController : BaseController
    {
        // GET: Team
        public ActionResult Index(string searchString,int? classidsearch, int page = 1, int pageSize = 5)
        {

            var dao = new Teamdow();
            var model = dao.ListAllPaging(searchString, classidsearch, page, pageSize);
            ViewBag.SearchString = searchString;
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
            var team = new Teamdow().ViewDetail(id);
            return View(team);
        }
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                var dao = new Teamdow();               
                long id = dao.Insert(team);
                if (id > 0)
                {
                    SetAlert("Thêm đội thành công", "success");
                    return RedirectToAction("Index", "Team");
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
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                var dao = new Teamdow();           
                var result = dao.Update(team);
                if (result)
                {
                    SetAlert("Sửa Đội thành công", "success");
                    return RedirectToAction("Index", "Team");
                }
                else
                {
                    ModelState.AddModelError("", "Câp nhập đội thành công");
                }
            }
            return View("Index");

        }
        public ActionResult Delete(int id)
        {
            new Teamdow().Delete(id);
            return RedirectToAction("Index");

        }
        public void SetViewBag(int selectedclass=0, int selectedgame=0)
        {
            
            var dao1 = new Gamedow();
            ViewBag.GameID = new SelectList(dao1.ListAll(), "ID", "Name", selectedgame);
            var dao = new Classdow();
            ViewBag.ClassID = new SelectList(dao.ListAll(), "ID", "Name", selectedclass);
        }
    }
}