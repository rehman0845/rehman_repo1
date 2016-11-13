using AngularCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AngularCrud.Controllers
{
        
    public class Student1Controller : Controller
    {
        private rehmanEntities1 re = null;
        private IRepository repository = null;
        public Student1Controller()
        {
            repository = new StudentRepository();
            re = new rehmanEntities1();
        }
        // GET: Student1
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var list = (List<Student>)repository.Getall();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult courseList()
        //{

        //    return Json(re.Students.Select(s => s.course).Distinct().ToList(), JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public string Insert(Student stud)
        {
            repository.Create(stud);
            repository.Save();
            return "Created Sucessfully";
        }
        [HttpPost]
        public string Update(Student stud)
        {
            repository.Update(stud);
            repository.Save();
            return "updated Sucessfully";
        }
        
        [HttpGet]
        public JsonResult courseList()
        {
            return Json(re.Students.Select(s => s.course).Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Edit(int? sno)
        {
           var st= repository.GetById(sno);
           return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Remove(Student stud)
        {
            repository.Delete(stud);
            repository.Save();
            return "deleted Sucessfully";
        }
        public JsonResult SearchItem(string str)
        {
            List<Student> list=null;
            if (str == "" || str==null)
                list = re.Students.ToList();
            else
                list = re.Students.Where(s => s.course == str).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}