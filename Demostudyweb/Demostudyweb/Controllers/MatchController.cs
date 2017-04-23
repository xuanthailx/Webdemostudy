using Model.Dow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demostudyweb.Controllers
{
    public class MatchController : Controller
    {
        private int totalRecord = 0;
        // GET: Match
        public ActionResult Index()
        {
            ViewBag.Title = "Match index?";
            ViewBag.Matches = new MatchDao().ListAllMatch(ref totalRecord);
            return View();
        }
    }
}