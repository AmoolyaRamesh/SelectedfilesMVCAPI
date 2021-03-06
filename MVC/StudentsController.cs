﻿using Logger;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StudentsController : Controller

    {
        private Ilog _Ilog;
        public StudentsController()
        {
            _Ilog = Log.GetInstance;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _Ilog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Students
        public ActionResult Index()
        {
            IEnumerable<mvcStudentModel> studentList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Students").Result;
            studentList = response.Content.ReadAsAsync<IEnumerable<mvcStudentModel>>().Result;
            return View(studentList);
            
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcStudentModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Students/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcStudentModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcStudentModel student)
        {
            if (student.StuentId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Students", student).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Students/" + student.StuentId, student).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Students/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}