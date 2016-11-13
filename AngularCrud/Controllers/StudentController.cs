using AngularCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AngularCrud.Controllers
{
    public class StudentController : Controller
    {
        
        // GET: Student
        rehmanEntities1 re = new rehmanEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        { 
            return Json(re.Students.ToList(),JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult courseList()
        {
            return Json(re.Students.Select(s=>s.course).Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(Student stud)
        {
            re.Students.Add(stud);
            re.SaveChanges();
            return Json("Created Sucessfully",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Student stud)
        {
            var st=re.Students.Where(s=>s.sno == stud.sno).FirstOrDefault();
            st.sname=stud.sname;
            st.course = stud.course;
            st.fee=stud.fee;
            re.SaveChanges();
            return Json("updated Sucessfully",JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Edit(int? id)
        {
            return Json(re.Students.Where(s=>s.sno == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Remove(Student stud)
        {
            var st=re.Students.Where(s=>s.sno == stud.sno).FirstOrDefault();
            re.Students.Remove(st);
            re.SaveChanges();
            return Json("deleted Sucessfully",JsonRequestBehavior.AllowGet);
        }
    }
}