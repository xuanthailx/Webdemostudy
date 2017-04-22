using Demostudyweb.Areas.Admin.Models;
using Demostudyweb.Common;
using model.Dow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demostudyweb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public string USER { get; private set; }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model) {
            if (ModelState.IsValid)
            {
                var dow = new Userdow();
                var result = dow.login(model.eMail, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dow.GetByID(model.eMail);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Email;
                    userSession.UserID = user.ID;
                    Session.Add(Commoncontent.USER_SESSION , userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
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
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }
           
    }
}