
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAoi.Models;

namespace StoreApp.Tests
{
    internal class StudentsController : ApiController
    {
        Student[] stu = new Student[]
{
            new Student { StudentId=1,StudentName="Amoolya",Stream="Electrical",StudentPercentage=90 },
             new Student { StudentId=2,StudentName="Chirag",Stream="Electronics",StudentPercentage=95 },
              

};
        private List<Student> testStudents;
       

        public StudentsController(System.Collections.Generic.List<Student> testStudents)
        {
            this.testStudents = testStudents;
        }
        public List<Student> GetAllStudents()
        {
            return testStudents;
        }
        public IHttpActionResult GetStudents(int id)
        {
            var stude = stu.Where(x => x.StudentId == id).FirstOrDefault();
            if (stude == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stude);
            }
        }
    }
}