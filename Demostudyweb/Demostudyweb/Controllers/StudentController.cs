﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model.Dow;
using Model.Dow;
using Model.EF;
namespace Demostudyweb.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var dao = new Studentdow();
            var model = dao.ListAllPaging(searchString, page, pageSize);
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
                     
            var student = new Studentdow().GetByID(id);
            SetViewBag(student.ID);
            return View(student);
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var dao = new Studentdow();
                long id = dao.Insert(student);
                if (id > 0)
                {
                    SetAlert("Thêm thông tin sinh viên thành công", "success");
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra xin nhập lại");
                }
            }
            SetViewBag();
            return View("Create");

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var dao = new Studentdow();
                var result = dao.Update(student);
                if (result)
                {
                    SetAlert("Sửa thông tin sinh viên thành công", "success");
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra xin nhập lại");
                }
            }
            return View("Index");

        }
        public void SetViewBag(int selectedclass = 0,string selectedemail = null)
        {
           
            var dao1 = new Classdow();
            ViewBag.ClassID = new SelectList(dao1.ListAll(), "ID", "Name", selectedclass);
            var dao = new Emaildow();
            ViewBag.Email = new SelectList(dao.ListAll(), "Email1", "Email1", selectedemail);
        }

    }
}