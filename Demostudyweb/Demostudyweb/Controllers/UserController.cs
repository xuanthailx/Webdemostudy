using Demostudyweb.Common;
using Demostudyweb.Models;
using model.Dow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demostudyweb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dow = new Userdow();
                var result = dow.login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 4 || result == 3)
                {
                    var user = dow.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Email;
                    userSession.UserID = user.ID;
                    userSession.UserRole = user.Role;
                    Session.Add(Commoncontent.USER_SESSION, userSession);
                    return RedirectToAction("Detail","TeamDetail");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "BẠn không có quyền truy cập trang này");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View(model);
        }   
        

    }

}
