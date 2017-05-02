using Demostudyweb.Common;
using model.Dow;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.Dow;

namespace Demostudyweb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private string encryptedMd5Pas;

        // GET: Admin/User
        public ActionResult Index( string searchString, int page=1,int pageSize = 2 )
        {
       
            var dao = new Userdow();
            var model = dao.ListAllPaging(searchString,page, pageSize);
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
            var user = new Userdow().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create( User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new Userdow();
                encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm Tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            SetViewBag();
            return View("Index");
    
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new Userdow();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }
               
               
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa Tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Câp nhập tài khoản thành công");
                }
            }
            return View("Index");

        }
        public ActionResult Delete(int id)
        {
            new Userdow().Delete(id);
            return RedirectToAction("Index");

        }
        public void SetViewBag(string selectedemail = null)
        {
            var dao = new Emaildow();
            ViewBag.Email = new SelectList(dao.ListAll(), "Email1", "Email1", selectedemail); 
        }
    }
}