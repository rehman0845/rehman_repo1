using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularCrud.Models
{
     interface IRepository
    {
         List<Student> Getall();
         Student GetById(int? sno);
         void Create(Student st);
         void Update(Student st);
         void Delete(Student st);
         void Save();
    }
}
