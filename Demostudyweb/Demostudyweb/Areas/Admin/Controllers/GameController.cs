using Model.Dow;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demostudyweb.Areas.Admin.Controllers
{
    public class GameController : BaseController
    {
        // GET: Admin/Game
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {

            var dao = new Gamedow();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var game = new Gamedow().ViewDetail(id);
            return View(game);
        }
        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                var dao = new Gamedow();                             
                long id = dao.Insert(game);
                if (id > 0)
                {
                    SetAlert("Thêm Môn thi đấu thành công", "success");
                    return RedirectToAction("Index", "Game");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Môn thi đấu không thành công");
                }
            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                var dao = new Gamedow();               
                var result = dao.Update(game);
                if (result)
                {
                    SetAlert("Sửa Môn thi đấu thành công", "success");
                    return RedirectToAction("Index", "Game");
                }
                else
                {
                    ModelState.AddModelError("", "Câp nhập Môn thi đấu không thành công");
                }
            }
            return View("Index");

        }
        public ActionResult Delete(int id)
        {
            new Gamedow().Delete(id);
            return RedirectToAction("Index");

        }       
    }
}