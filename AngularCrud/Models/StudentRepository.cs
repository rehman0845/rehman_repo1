using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularCrud.Models
{
    class StudentRepository:IRepository
    {
        private rehmanEntities1 re=null;
        public StudentRepository()
        {
            re=new rehmanEntities1();
        }
        public List<Student> Getall() 
        {
            var list = re.Students.ToList();
            return list;
        }
        public Student GetById(int? sno)
        {
            var st = re.Students.Where(s => s.sno == sno).FirstOrDefault();
            return st;
        }
        public void Create(Student stud)
        {
            re.Students.Add(stud);
        }
        public void Update(Student stud)
        {
            var st = re.Students.Where(s => s.sno == stud.sno).FirstOrDefault();
            st.sname = stud.sname;
            st.course = stud.course;
            st.fee = stud.fee;
        }
        public void Delete(Student stud)
        {
            var st = re.Students.Where(s => s.sno == stud.sno).FirstOrDefault();
            re.Students.Remove(st);
        }
        public void Save()
        {
            re.SaveChanges();
        }
    }
}
